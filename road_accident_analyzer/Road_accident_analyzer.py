from PyQt5 import QtWidgets, QtCore
from design import Ui_MainWindow
import data_and_algorithms
import sys
import threading


class PandasModel(QtCore.QAbstractTableModel):
    def __init__(self, dataframe: data_and_algorithms.pd.DataFrame, parent=None):
        QtCore.QAbstractTableModel.__init__(self, parent)
        self._dataframe = dataframe

    def rowCount(self, parent=QtCore.QModelIndex()) -> int:
        if parent == QtCore.QModelIndex():
            return len(self._dataframe)
        return 0

    def columnCount(self, parent=QtCore.QModelIndex()) -> int:
        if parent == QtCore.QModelIndex():
            return len(self._dataframe.columns)
        return 0

    def data(self, index: QtCore.QModelIndex, role=QtCore.Qt.ItemDataRole):
        if not index.isValid():
            return None
        if role == QtCore.Qt.DisplayRole:
            return str(self._dataframe.iloc[index.row(), index.column()])
        return None

    def headerData(self, section: int, orientation: QtCore.Qt.Orientation, role: QtCore.Qt.ItemDataRole):
        if role == QtCore.Qt.DisplayRole:
            if orientation == QtCore.Qt.Horizontal:
                return str(self._dataframe.columns[section])
            if orientation == QtCore.Qt.Vertical:
                return str(self._dataframe.index[section])
        return None


class MyWindow(QtWidgets.QMainWindow):
    def __init__(self):
        super(MyWindow, self).__init__()
        self.ui = Ui_MainWindow()
        self.ui.setupUi(self)

        self.ui.tabWidget.setTabShape(QtWidgets.QTabWidget.Triangular)
        self.ui.combo_street.setEnabled(False)
        self.ui.radio_all.setChecked(True)
        self.radio_button_group = QtWidgets.QButtonGroup()
        self.radio_button_group.addButton(self.ui.radio_all)
        self.radio_button_group.addButton(self.ui.radio_crossroad)

        self.ui.change_file.clicked.connect(self.change_file_clicked)
        self.ui.clear.clicked.connect(self.clear_clicked)
        self.ui.download.clicked.connect(self.download_clicked)
        self.ui.calc_range_fac.clicked.connect(self.range_factors)
        self.ui.calc_range_type.clicked.connect(self.range_types)
        self.ui.combo_district.currentIndexChanged.connect(self.change_districts)
        self.ui.combo_street.currentIndexChanged.connect(self.change_streets)
        self.ui.combo_type.currentIndexChanged.connect(self.change_types)
        self.ui.combo_factor.currentIndexChanged.connect(self.change_factors)

    def change_file_clicked(self):
        res = QtWidgets.QFileDialog.getOpenFileName(self, 'Open File', '/', 'Excel File (*.xlsx *.xls)')[0]
        self.ui.file_name.clear()
        self.ui.file_name.append(res)

    def clear_clicked(self):
        self.ui.file_name.clear()

    def download_clicked(self):
        file = self.ui.file_name.toPlainText()
        if file == '':
            self.ui.info_text.append('Вы не выбрали файл для загрузки!')
        else:
            try:
                temp_file = open(file, 'r')
                temp_file.close()
                self.ui.info_text.append('Дождитесь окончания загрузки...')
                thr1 = threading.Thread(target=self.data_proc, args=(file,)).start()
            except IOError:
                self.ui.info_text.append('Проблема с открытием файла. Проверьте путь и название файла!')

    def data_proc(self, filename):
        data_and_algorithms.set_initial_data(filename)
        self.ui.info_text.append('Начало загрузки...')
        flag_crossroad = False
        if self.radio_button_group.checkedButton() == self.ui.radio_crossroad:
            flag_crossroad = True
        data_and_algorithms.data_processing(flag_crossroad)
        model = PandasModel(data_and_algorithms.DATA)
        self.ui.data_table.setModel(model)
        self.ui.data_table.show()
        self.range_param()
        self.ui.info_text.append('Загрузка завершена!')

    def range_param(self):
        self.ui.combo_district.clear()
        self.ui.combo_district.addItem('Все')
        self.ui.combo_district.addItems(data_and_algorithms.all_districts())
        self.ui.combo_district.setCurrentIndex(0)

    def change_districts(self):
        text = self.ui.combo_district.currentText()
        self.ui.combo_street.clear()
        if text == 'Все':
            self.ui.combo_street.setEnabled(False)
        else:
            self.ui.combo_street.setEnabled(True)
            self.ui.combo_street.addItem('Все')
            self.ui.combo_street.addItems(data_and_algorithms.all_streets(text))
            self.ui.combo_street.setCurrentIndex(0)
        self.change_report()

    def change_streets(self):
        self.change_report()

    def change_report(self):
        district = self.ui.combo_district.currentText()
        if self.ui.combo_street.isEnabled():
            street = self.ui.combo_street.currentText()
        else:
            street = 'Все'
        data_and_algorithms.make_report(district, street)
        self.ui.combo_type.clear()
        self.ui.combo_type.addItems(data_and_algorithms.all_types_dtp())
        self.ui.combo_factor.clear()
        self.ui.combo_factor.addItems(data_and_algorithms.all_factors_dtp())
        self.ui.count_dtp.display(data_and_algorithms.count_dtp())

    def change_types(self):
        if self.ui.combo_type.currentText() != '':
            self.ui.count_dtp_type.display(data_and_algorithms.count_dtp_by_type(self.ui.combo_type.currentText()))
            self.ui.combo_count_factor.clear()
            count_factors = data_and_algorithms.count_factors_by_type(self.ui.combo_type.currentText())
            for number in range(count_factors, 0, -1):
                self.ui.combo_count_factor.addItem(str(number))

    def change_factors(self):
        if self.ui.combo_factor.currentText() != '':
            self.ui.count_dtp_factor.display(
                data_and_algorithms.count_dtp_by_factor(self.ui.combo_factor.currentText()))
            self.ui.combo_count_type.clear()
            count_types = data_and_algorithms.count_types_by_factor(self.ui.combo_factor.currentText())
            for number in range(count_types, 0, -1):
                self.ui.combo_count_type.addItem(str(number))

    def range_factors(self):
        current_type = self.ui.combo_type.currentText()
        if current_type != '':
            result = data_and_algorithms.ranking_of_alternatives_by_criteria(int(self.ui.combo_count_factor.currentText()),
                                                                             type_dtp=current_type)
            model = PandasModel(result)
            self.ui.table_factor.setModel(model)
            self.ui.table_factor.verticalHeader().hide()
            self.ui.table_factor.setColumnWidth(0, 493)
            self.ui.table_factor.setColumnWidth(1, 140)
            self.ui.table_factor.show()

    def range_types(self):
        current_factor = self.ui.combo_factor.currentText()
        if current_factor != '':
            result = data_and_algorithms.ranking_of_alternatives_by_criteria(int(self.ui.combo_count_type.currentText()),
                                                                             factor_dtp=current_factor)
            model = PandasModel(result)
            self.ui.table_type.setModel(model)
            self.ui.table_type.verticalHeader().hide()
            self.ui.table_type.setColumnWidth(0, 514)
            self.ui.table_type.setColumnWidth(1, 140)
            self.ui.table_type.show()


def main():
    app = QtWidgets.QApplication([])
    window = MyWindow()
    window.show()
    sys.exit(app.exec_())


if __name__ == '__main__':
    main()
