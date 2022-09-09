import pandas as pd
import numpy as np
import scipy.stats as sps

# Общие данные о ДТП
DATA = pd.DataFrame()
# Данные о ДТП по выбранному району (улице)
LOCAL_DATA = pd.DataFrame()
# Сводка для расчета факторов
REPORT = pd.DataFrame()


def set_initial_data(filename):
    global DATA
    try:
        DATA = pd.read_excel(filename, sheet_name='Sheet1')
    except ValueError:
        DATA = pd.read_excel(filename, sheet_name='Лист1')


def number_of_columns(column):
    max_count = 0
    temp_values = []
    for val in column:
        if pd.isnull(val) and len(temp_values) > 0:
            if max_count < len(temp_values):
                max_count = len(temp_values)
            temp_values = []
        elif not pd.isnull(val) and val != 'Нет нарушений' and val not in temp_values:
            temp_values.append(val)
    return max_count


def string_processing(string, temp_ndu, temp_OBJ_DTP, temp_sdor, temp_NPDD, temp_SOP_NPDD, temp_NPDD4, temp_SOP_NPDD7):
    if len(temp_ndu) > 0:
        string['ndu'] = temp_ndu[0]
        if len(temp_ndu) > 1:
            for ind1 in range(1, len(temp_ndu)):
                string['ndu' + str(ind1)] = temp_ndu[ind1]
    if len(temp_OBJ_DTP) > 0:
        string['OBJ_DTP'] = temp_OBJ_DTP[0]
        if len(temp_OBJ_DTP) > 1:
            for ind2 in range(1, len(temp_OBJ_DTP)):
                string['OBJ_DTP' + str(ind2)] = temp_OBJ_DTP[ind2]
    if len(temp_sdor) > 0:
        string['sdor'] = temp_sdor[0]
        if len(temp_sdor) > 1:
            for ind3 in range(1, len(temp_sdor)):
                string['sdor' + str(ind3)] = temp_sdor[ind3]
    if len(temp_NPDD) > 0:
        string['NPDD'] = temp_NPDD[0]
        if len(temp_NPDD) > 1:
            for ind4 in range(1, len(temp_NPDD)):
                string['NPDD' + str(ind4)] = temp_NPDD[ind4]
    if len(temp_SOP_NPDD) > 0:
        string['SOP_NPDD'] = temp_SOP_NPDD[0]
        if len(temp_SOP_NPDD) > 1:
            for ind5 in range(1, len(temp_SOP_NPDD)):
                string['SOP_NPDD' + str(ind5)] = temp_SOP_NPDD[ind5]
    if len(temp_NPDD4) > 0:
        string['NPDD4'] = temp_NPDD4[0]
        if len(temp_NPDD4) > 1:
            for ind6 in range(1, len(temp_NPDD4)):
                string['NPDD4' + str(ind6)] = temp_NPDD4[ind6]
    if len(temp_SOP_NPDD7) > 0:
        string['SOP_NPDD7'] = temp_SOP_NPDD7[0]
    return string


def crossroad_dtp():
    substring_1 = 'перекрёсток'
    substring_2 = 'перекресток'
    fullstring_1 = []
    fullstring_2 = []
    result = pd.DataFrame()
    for ind, row in DATA.iterrows():
        fullstring_1.extend([row['OBJ_DTP'], row['OBJ_DTP1'], row['OBJ_DTP2'], row['OBJ_DTP3']])
        fullstring_2.extend([row['sdor'], row['sdor1']])
        flag = True
        for string in fullstring_1:
            if not pd.isna(string):
                if string.find(substring_1) != -1:
                    result = pd.concat([result, DATA.iloc[[ind]]], ignore_index=True)
                    flag = False
                    break
        if flag:
            for string in fullstring_2:
                if not pd.isna(string):
                    if string.find(substring_2) != -1:
                        result = pd.concat([result, DATA.iloc[[ind]]], ignore_index=True)
                        flag = False
                        break
        fullstring_1 = []
        fullstring_2 = []

    return result


def data_processing(flag_crossroad):
    global DATA
    # Удаление ненужных столбцов
    temp_data_columns_list = DATA.columns
    should_columns_list = ['DTPV', 'date', 'district', 'CHOM', 'ndu', 'OBJ_DTP', 'osv', 's_pch', 'sdor', 'spog',
                           'street', 'NPDD', 'SOP_NPDD', 'NPDD4', 'SOP_NPDD7', 'KUCH', 'kartId', 'POG11', 'RAN12',
                           'time']
    for val in temp_data_columns_list:
        if val not in should_columns_list:
            DATA.pop(val)

    # Подсчет количества дополнительных столбцов
    ndu = DATA['ndu']
    max_count_ndu = number_of_columns(ndu)
    OBJ_DTP = DATA['OBJ_DTP']
    max_count_OBJ_DTP = number_of_columns(OBJ_DTP)
    sdor = DATA['sdor']
    max_count_sdor = number_of_columns(sdor)
    NPDD = DATA['NPDD']
    max_count_NPDD = number_of_columns(NPDD)
    SOP_NPDD = DATA['SOP_NPDD']
    max_count_SOP_NPDD = number_of_columns(SOP_NPDD)
    NPDD4 = DATA['NPDD4']
    max_count_NPDD4 = number_of_columns(NPDD4)
    SOP_NPDD7 = DATA['SOP_NPDD7']
    max_count_SOP_NPDD7 = number_of_columns(SOP_NPDD7)

    # Создание дополнительных столбцов
    header_list = DATA.columns.values
    for ind1 in range(1, max_count_ndu):
        header_list = np.append(header_list, 'ndu' + str(ind1))
    for ind2 in range(1, max_count_OBJ_DTP):
        header_list = np.append(header_list, 'OBJ_DTP' + str(ind2))
    for ind3 in range(1, max_count_sdor):
        header_list = np.append(header_list, 'sdor' + str(ind3))
    for ind4 in range(1, max_count_NPDD):
        header_list = np.append(header_list, 'NPDD' + str(ind4))
    for ind5 in range(1, max_count_SOP_NPDD):
        header_list = np.append(header_list, 'SOP_NPDD' + str(ind5))
    for ind6 in range(1, max_count_NPDD4):
        header_list = np.append(header_list, 'NPDD4' + str(ind6))
    for ind7 in range(1, max_count_SOP_NPDD7):
        header_list = np.append(header_list, 'SOP_NPDD7' + str(ind7))
    DATA = DATA.reindex(columns=header_list)

    # Объединение строк
    temp_ndu = []
    temp_OBJ_DTP = []
    temp_sdor = []
    temp_NPDD = []
    temp_SOP_NPDD = []
    temp_NPDD4 = []
    temp_SOP_NPDD7 = []
    temp_id = DATA['kartId'][0]
    result = pd.DataFrame()
    temp_str = DATA.head(1)
    for ind, row in DATA.iterrows():
        if row['kartId'] != temp_id:
            temp_id = row['kartId']
            temp_str = string_processing(temp_str, temp_ndu, temp_OBJ_DTP, temp_sdor, temp_NPDD, temp_SOP_NPDD,
                                         temp_NPDD4, temp_SOP_NPDD7)
            result = pd.concat([result, temp_str], ignore_index=True)
            temp_str = DATA.iloc[[ind]]
            temp_ndu = []
            temp_OBJ_DTP = []
            temp_sdor = []
            temp_NPDD = []
            temp_SOP_NPDD = []
            temp_NPDD4 = []
            temp_SOP_NPDD7 = []
        else:
            if row['ndu'] not in temp_ndu and not (pd.isnull(row['ndu'])):
                temp_ndu.append(row['ndu'])
            elif row['OBJ_DTP'] not in temp_OBJ_DTP and not (pd.isnull(row['OBJ_DTP'])):
                temp_OBJ_DTP.append(row['OBJ_DTP'])
            elif row['sdor'] not in temp_sdor and not (pd.isnull(row['sdor'])):
                temp_sdor.append(row['sdor'])
            elif row['NPDD'] not in temp_NPDD and not (pd.isnull(row['NPDD'])) and not (row['NPDD'] == 'Нет нарушений'):
                temp_NPDD.append(row['NPDD'])
                if row['SOP_NPDD'] not in temp_SOP_NPDD and not (pd.isnull(row['SOP_NPDD'])) and not (
                        row['SOP_NPDD'] == 'Нет нарушений'):
                    temp_SOP_NPDD.append(row['SOP_NPDD'])
            elif row['SOP_NPDD'] not in temp_SOP_NPDD and not (pd.isnull(row['SOP_NPDD'])) and not (
                    row['SOP_NPDD'] == 'Нет нарушений'):
                temp_SOP_NPDD.append(row['SOP_NPDD'])
            elif row['NPDD4'] not in temp_NPDD4 and not (pd.isnull(row['NPDD4'])) and not (
                    row['NPDD4'] == 'Нет нарушений'):
                temp_NPDD4.append(row['NPDD4'])
                if row['SOP_NPDD7'] not in temp_SOP_NPDD7 and not (pd.isnull(row['SOP_NPDD7'])) and not (
                        row['SOP_NPDD7'] == 'Нет нарушений'):
                    temp_SOP_NPDD7.append(row['SOP_NPDD7'])
            elif row['SOP_NPDD7'] not in temp_SOP_NPDD7 and not (pd.isnull(row['SOP_NPDD7'])) and not (
                    row['SOP_NPDD7'] == 'Нет нарушений'):
                temp_SOP_NPDD7.append(row['SOP_NPDD7'])
    temp_str = string_processing(temp_str, temp_ndu, temp_OBJ_DTP, temp_sdor, temp_NPDD, temp_SOP_NPDD,
                                 temp_NPDD4, temp_SOP_NPDD7)
    result = pd.concat([result, temp_str], ignore_index=True)
    DATA = result

    # Выделение аварий на перекрестках
    if flag_crossroad:
        DATA = crossroad_dtp()


def adding_columns(df, columns):
    header_list = df.columns.values
    for head in columns:
        header_list = np.append(header_list, head)
    return df.reindex(columns=header_list)


def delete_duplicate_columns(df):
    col_names = set()
    ind_new_cols = list()
    for ind_column, name in enumerate(df.columns):
        if name not in col_names:
            col_names.add(name)
            ind_new_cols.append(ind_column)
    return df.iloc[:, ind_new_cols]


def delete_extra_columns(df):
    current_header_list = df.columns.tolist()
    extra_columns_list = ['Иные недостатки', 'Другие нарушения ПДД водителем',
                          'Другие нарушения ПДД водителями (не применяется с 12.2020)', 'Иные нарушения',
                          'Нарушение водителем правил применения ремней безопасности (ставится в случае, когда не '
                          'пристегнут водитель)', 'Оставление места ДТП',
                          'Нарушение водителем правил применения ремней безопасности (ставится в случае, когда не '
                          'пристегнут пассажир)',
                          'Нарушение правил перевозки детей (не использование детских сидений либо удерживающих '
                          'устройств)', 'Нарушение правил перевозки людей', 'Нарушение правил применения мотошлема',
                          'Нарушение правил применения ремней безопасности пассажиром', 'Несоблюдение требований ОСАГО',
                          'Отказ водителя от прохождения медицинского освидетельствования на состояние опьянения',
                          'Отказ водителя, не имеющего права управления ТС либо лишенного права управления ТС, '
                          'от прохождения медицинского освидетельствования на состояние опьянения (не применяется с '
                          '12.2020)', 'Отсутствие у водителя документов, предусмотренных законодательными и иными НПА',
                          'Употребление водителем алкогольных напитков, наркотических, психотропных или иных '
                          'одурманивающих веществ после дорожно-транспортного происшествия, к которому он причастен, '
                          'до проведения освидетельствования с целью установления состояния опьянения или до принятия '
                          'решения об освобождении от проведения такого освидетельствовани',
                          'Управление ТС лицом, находящимся в состоянии алкогольного опьянения и не имеющим права '
                          'управления ТС либо лишенным права управления ТС (не применяется с 12.2020)',
                          'Управление ТС лицом, находящимся в состоянии наркотического опьянения и не имеющим права '
                          'управления ТС либо лишенным права управления ТС (не применяется с 12.2020)']
    new_header_list = []
    for header in current_header_list:
        if header not in extra_columns_list:
            new_header_list.append(header)
    return df.reindex(columns=new_header_list)


def make_report(district, street):
    global REPORT
    global LOCAL_DATA
    if district != 'Все':
        if street != 'Все':
            local_data = DATA[(DATA['district'] == district) & (DATA['street'] == street)]
        else:
            local_data = DATA[(DATA['district'] == district)]
    else:
        local_data = DATA
    LOCAL_DATA = local_data
    dtpV = local_data['DTPV'].unique()
    report = pd.DataFrame()
    # Установка строк сводки
    report.index = dtpV

    # Нарушения дорожных условий
    ndu = local_data['ndu'].unique()
    ndu1 = local_data['ndu1'].unique()
    ndu2 = local_data['ndu2'].unique()
    ndu3 = local_data['ndu3'].unique()
    ndu = np.hstack((ndu, ndu1, ndu2, ndu3))
    ndu = np.unique(np.delete(ndu, np.where(pd.isnull(ndu))))
    ndu = np.delete(ndu, np.where(ndu == 'Не установлены'))
    # Добавление новых столбцов
    report = adding_columns(report, ndu)
    # Сводка по нарушениям дорожных условий
    for item in ndu:
        for v in dtpV:
            report.loc[v, item] = len(local_data[(local_data['DTPV'] == v) & ((local_data['ndu'] == item) |
                                                                              (local_data['ndu1'] == item) |
                                                                              (local_data['ndu2'] == item) |
                                                                              (local_data['ndu3'] == item))])

    # Нарушения ПДД водителями
    npdd = local_data['NPDD'].unique()
    npdd1 = local_data['NPDD1'].unique()
    npdd = np.hstack((npdd, npdd1))
    npdd = np.unique(np.delete(npdd, np.where(pd.isnull(npdd))))

    # Сопутствующие нарушения ПДД водителями
    sop_npdd = local_data['SOP_NPDD'].unique()
    sop_npdd1 = local_data['SOP_NPDD1'].unique()
    sop_npdd2 = local_data['SOP_NPDD2'].unique()
    sop_npdd3 = local_data['SOP_NPDD3'].unique()
    sop_npdd4 = local_data['SOP_NPDD4'].unique()
    sop_npdd5 = local_data['SOP_NPDD5'].unique()
    sop_npdd = np.hstack((sop_npdd, sop_npdd1, sop_npdd2, sop_npdd3, sop_npdd4, sop_npdd5))
    sop_npdd = np.unique(np.delete(sop_npdd, np.where(pd.isnull(sop_npdd))))

    # Все нарушения ПДД водителями
    npdd = np.unique(np.hstack((npdd, sop_npdd)))
    # Добавление новых столбцов
    report = adding_columns(report, npdd)
    # Сводка по нарушениям ПДД водителями
    for item in npdd:
        for v in dtpV:
            report.loc[v, item] = len(local_data[(local_data['DTPV'] == v) & ((local_data['NPDD'] == item)
                                                                              | (local_data['NPDD1'] == item)
                                                                              | (local_data['SOP_NPDD'] == item)
                                                                              | (local_data['SOP_NPDD1'] == item)
                                                                              | (local_data['SOP_NPDD2'] == item)
                                                                              | (local_data['SOP_NPDD3'] == item)
                                                                              | (local_data['SOP_NPDD4'] == item)
                                                                              | (local_data['SOP_NPDD5'] == item))])

    # Нарушения ПДД пешеходами
    pnpdd = local_data['NPDD4'].unique()
    pnpdd1 = local_data['NPDD41'].unique()
    pnpdd = np.hstack((pnpdd, pnpdd1))
    pnpdd = np.unique(np.delete(pnpdd, np.where(pd.isnull(pnpdd))))

    # Сопутствующие нарушения ПДД пешеходами
    sop_pnpdd = local_data['SOP_NPDD7'].unique()
    sop_pnpdd = np.unique(np.delete(sop_pnpdd, np.where(pd.isnull(sop_pnpdd))))

    # Все нарушения ПДД пешеходами
    pnpdd = np.unique(np.hstack((pnpdd, sop_pnpdd)))
    # Добавление новых столбцов
    report = adding_columns(report, pnpdd)
    # Сводка по нарушению ПДД пешеходами
    for item in pnpdd:
        for v in dtpV:
            report.loc[v, item] = len(local_data[(local_data['DTPV'] == v) & ((local_data['NPDD4'] == item)
                                                                              | (local_data['NPDD41'] == item)
                                                                              | (local_data['SOP_NPDD7'] == item))])
    # Удаление дубликатов столбцов
    report = delete_duplicate_columns(report)

    # Удаление ненужных стобцов
    report = delete_extra_columns(report)

    REPORT = report


def all_districts():
    return DATA['district'].unique()


def all_streets(district):
    tempDATA = DATA[(DATA['district'] == district)]
    tempDATA = tempDATA['street'].unique()
    return np.delete(tempDATA, np.where(pd.isnull(tempDATA)))


def all_types_dtp():
    return REPORT.index.tolist()


def all_factors_dtp():
    return REPORT.columns.tolist()


def count_dtp():
    return len(LOCAL_DATA)


def count_dtp_by_type(type_dtp):
    return len(LOCAL_DATA[(LOCAL_DATA['DTPV'] == type_dtp)])


def count_dtp_by_factor(factor_dtp):
    data = LOCAL_DATA[(LOCAL_DATA['ndu'] == factor_dtp) | (LOCAL_DATA['ndu1'] == factor_dtp)
                      | (LOCAL_DATA['ndu2'] == factor_dtp) | (LOCAL_DATA['ndu3'] == factor_dtp)
                      | (LOCAL_DATA['NPDD'] == factor_dtp) | (LOCAL_DATA['NPDD1'] == factor_dtp)
                      | (LOCAL_DATA['SOP_NPDD'] == factor_dtp) | (LOCAL_DATA['SOP_NPDD1'] == factor_dtp)
                      | (LOCAL_DATA['SOP_NPDD2'] == factor_dtp) | (LOCAL_DATA['SOP_NPDD3'] == factor_dtp)
                      | (LOCAL_DATA['SOP_NPDD4'] == factor_dtp) | (LOCAL_DATA['SOP_NPDD5'] == factor_dtp)
                      | (LOCAL_DATA['NPDD4'] == factor_dtp) | (LOCAL_DATA['NPDD41'] == factor_dtp)
                      | (LOCAL_DATA['SOP_NPDD7'] == factor_dtp)]
    return len(data)


def count_factors_by_type(type_dtp):
    factors = REPORT.T.sort_values(type_dtp, ascending=False)
    factors = factors[(factors[type_dtp] > 0)]
    count = len(factors)
    if count > 15:
        count = 15
    return count


def count_types_by_factor(factor_dtp):
    types = REPORT.sort_values(factor_dtp, ascending=False)
    types = types[(types[factor_dtp] > 0)]
    count = len(types)
    if count > 15:
        count = 15
    return count


def delete_criteria(dictionary):
    del_elements = []
    for key, val in dictionary.items():
        if val == 0:
            del_elements.append(key)
    if len(del_elements) > 0:
        for key in del_elements:
            del dictionary[key]


def dictionary_values(dictionary):
    vals = []
    for val in dictionary.values():
        vals.append(val)
    return vals


def dictionary_keys(dictionary):
    keys = []
    for key in dictionary.keys():
        keys.append(key)
    return keys


def count_alternatives_by_criterion(criteria, local_data, factor_dtp=None, type_dtp=None):
    if not (factor_dtp is None):
        data = local_data[(local_data['ndu'] == factor_dtp) | (local_data['ndu1'] == factor_dtp)
                          | (local_data['ndu2'] == factor_dtp) | (local_data['ndu3'] == factor_dtp)
                          | (local_data['NPDD'] == factor_dtp) | (local_data['NPDD1'] == factor_dtp)
                          | (local_data['SOP_NPDD'] == factor_dtp) | (local_data['SOP_NPDD1'] == factor_dtp)
                          | (local_data['SOP_NPDD2'] == factor_dtp) | (local_data['SOP_NPDD3'] == factor_dtp)
                          | (local_data['SOP_NPDD4'] == factor_dtp) | (local_data['SOP_NPDD5'] == factor_dtp)
                          | (local_data['NPDD4'] == factor_dtp) | (local_data['NPDD41'] == factor_dtp)
                          | (local_data['SOP_NPDD7'] == factor_dtp)]
    else:
        data = local_data[(local_data['DTPV'] == type_dtp)]

    count = 0
    if criteria == 'Режим движения':
        count = len(data[(data['CHOM'] == 'Движение частично перекрыто')
                         | (data['CHOM'] == 'Движение полностью перекрыто')])
    elif criteria == 'Раненые':
        count = sum(data['RAN12'])
    elif criteria == 'Погибшие':
        count = sum(data['POG11'])
    return count


def create_matrix_of_pairwise_comparisons(values):
    # Если один критерий/альтернатива, то матрица не требуется
    if len(values) == 1:
        return values

    # Инициализация матрицы
    matrix = np.zeros(shape=(len(values), len(values)))

    # Нулевые оценки заменяем на 1
    for ind_value, value in enumerate(values):
        if value == 0:
            values[ind_value] = 1

    # Сортировка значений по убыванию
    matrix_values = np.array(values)
    matrix_values = -np.sort(-matrix_values)

    # Если есть значения больше 9
    if matrix_values[0] > 9:
        minimal = matrix_values[len(matrix_values) - 1]
        step = (matrix_values[0] - minimal) / 8
        # Если одинаковые значения больше 9
        if step == 0:
            # Оценки больше 9 заменяем на 9
            for ind_value, value in enumerate(values):
                if value > 9:
                    values[ind_value] = 9
        # Приведение к шкале 1..9
        else:
            for ind_value, value in enumerate(values):
                values[ind_value] = (value - minimal) / step + 1

    # Итоговая матрица
    for i in range(0, len(values)):
        for j in range(i, len(values)):
            if i == j:
                matrix[i][j] = 1
            elif values[i] > values[j]:
                matrix[i][j] = values[i] / values[j]
                matrix[j][i] = 1 / matrix[i][j]
            else:
                matrix[j][i] = values[j] / values[i]
                matrix[i][j] = 1 / matrix[j][i]

    return matrix


def get_pss_value(number):
    pss_values = {
        1: 0,
        2: 0,
        3: 0.58,
        4: 0.9,
        5: 1.12,
        6: 1.24,
        7: 1.32,
        8: 1.41,
        9: 1.45,
        10: 1.49,
        11: 1.51,
        12: 1.48,
        13: 1.56,
        14: 1.57,
        15: 1.59
    }
    return pss_values[number]


def calculate_matrix_of_pairwise_comparisons(matrix):
    # Если критерий/альтернатива только один - вес равен 1
    if len(matrix) == 1:
        return [1], 0, 0

    # Суммы столбцов матрицы
    sum_columns_matrix = []
    for ind in range(0, len(matrix)):
        sum_columns_matrix.append(sum(matrix[:, ind]))
    # Геометрические средние строк
    geometric_averages_matrix = []
    for ind in range(0, len(matrix)):
        geometric_averages_matrix.append(sps.gmean(matrix[ind]))
    # Нормализованный вектор приоритетов
    nvp_matrix = []
    for val in geometric_averages_matrix:
        nvp_matrix.append(val / sum(geometric_averages_matrix))
    # Собственное значение матрицы
    lambda_max = 0
    for ind, s in enumerate(sum_columns_matrix):
        lambda_max += s * nvp_matrix[ind]
    # Индекс согласования
    approval_index = (lambda_max - len(nvp_matrix)) / (len(nvp_matrix) - 1)
    # Показатель случайной согласованности
    pss = get_pss_value(len(matrix))
    # Отношение согласованности
    if pss != 0:
        consistency_relation = approval_index / pss
    else:
        consistency_relation = 0
    return nvp_matrix, approval_index, consistency_relation


def mmai(nvp_alt, nvp_crit):
    # Нормализованные матрицы относительных ВКА по всем критериям
    list_matrix = []
    for row in nvp_alt:
        new_matrix = []
        for ind_first, alternative in enumerate(row):
            new_row = []
            for ind_second in range(0, len(row)):
                if ind_first == ind_second:
                    new_row.append([0.5, 0.5])
                else:
                    new_row.append([alternative / (alternative + row[ind_second]),
                                    row[ind_second] / (alternative + row[ind_second])])
            new_matrix.append(new_row)
        list_matrix.append(new_matrix)

    # Нормализованная матрица сверток частных оценок в каждой паре по всем критериям
    convolutions = []
    for row in range(0, len(list_matrix[0])):
        new_row = []
        for columns in range(0, len(list_matrix[0])):
            left = 0
            right = 0
            for ind_crit, val_crit in enumerate(nvp_crit):
                left += list_matrix[ind_crit][row][columns][0] * val_crit
                right += list_matrix[ind_crit][row][columns][1] * val_crit
            new_row.append([left / (left + right), right / (left + right)])
        convolutions.append(new_row)

    # Получение итоговых оценок методом ММАИ
    new_nvp_alt = []
    for row in convolutions:
        left = 0
        for column in row:
            left += column[0]
        new_nvp_alt.append(left)
    sum_new_nvp_alt = sum(new_nvp_alt)
    for ind in range(0, len(new_nvp_alt)):
        new_nvp_alt[ind] /= sum_new_nvp_alt
    return new_nvp_alt


def ranking_of_alternatives_by_criteria(count_alternatives, type_dtp=None, factor_dtp=None):
    # Выделение списка текущих аварий
    # Если ранжируем факторы по типам
    if not (type_dtp is None):
        current_data = LOCAL_DATA[(LOCAL_DATA['DTPV'] == type_dtp)]
    # Если ранжируем типы по факторам
    elif not (factor_dtp is None):
        current_data = LOCAL_DATA[(LOCAL_DATA['ndu'] == factor_dtp) | (LOCAL_DATA['ndu1'] == factor_dtp)
                                  | (LOCAL_DATA['ndu2'] == factor_dtp) | (LOCAL_DATA['ndu3'] == factor_dtp)
                                  | (LOCAL_DATA['NPDD'] == factor_dtp) | (LOCAL_DATA['NPDD1'] == factor_dtp)
                                  | (LOCAL_DATA['SOP_NPDD'] == factor_dtp) | (LOCAL_DATA['SOP_NPDD1'] == factor_dtp)
                                  | (LOCAL_DATA['SOP_NPDD2'] == factor_dtp) | (LOCAL_DATA['SOP_NPDD3'] == factor_dtp)
                                  | (LOCAL_DATA['SOP_NPDD4'] == factor_dtp) | (LOCAL_DATA['SOP_NPDD5'] == factor_dtp)
                                  | (LOCAL_DATA['NPDD4'] == factor_dtp) | (LOCAL_DATA['NPDD41'] == factor_dtp)
                                  | (LOCAL_DATA['SOP_NPDD7'] == factor_dtp)]
    # В случае запуска без параметров - возврат пустого датафрейма
    else:
        return pd.DataFrame()

    # Подсчет количества ДТП, случаев нарушения движения, раненых и погибших
    temp_count_dtp = len(current_data)
    chom = current_data['CHOM'].unique()
    chom = np.delete(chom, np.where(chom == 'Режим движения не изменялся'))
    count_chom = 0
    if len(chom) > 0:
        for item in chom:
            count_chom += len(current_data[(current_data['CHOM'] == item)])
    count_ran = sum(current_data['RAN12'])
    count_pog = sum(current_data['POG11'])

    # Список критериев
    # Если ранжируем факторы по типам
    if not (type_dtp is None):
        criteria = {'Тип ДТП': temp_count_dtp, 'Режим движения': count_chom, 'Раненые': count_ran,
                    'Погибшие': count_pog}
    # Если ранжируем типы по факторам
    else:
        criteria = {'Фактор ДТП': temp_count_dtp, 'Режим движения': count_chom, 'Раненые': count_ran,
                    'Погибшие': count_pog}
    delete_criteria(criteria)
    print(criteria)
    criteria_keys = dictionary_keys(criteria)
    criteria_values = dictionary_values(criteria)
    if 'Погибшие' in criteria_keys:
        max_criteria_value = max(criteria_values)
        if max_criteria_value < 9:
            max_criteria_value = 9
        for ind_crit, key in enumerate(criteria_keys):
            if key == 'Погибшие':
                criteria_values[ind_crit] = max_criteria_value
                break

    # Матрица попарных сравнений критериев
    criteria_matrix = create_matrix_of_pairwise_comparisons(criteria_values)

    # Выделение альтернатив
    # Если ранжируем факторы по типам
    if not (type_dtp is None):
        # Выделение значимых факторов для данного вида ДТП (до 15 штук)
        locale_REPORT = REPORT.T.sort_values(type_dtp, ascending=False)
        locale_REPORT = locale_REPORT[(locale_REPORT[type_dtp] > 0)]
        if len(locale_REPORT) > count_alternatives:
            locale_REPORT = locale_REPORT[0:count_alternatives]
        locale_REPORT = locale_REPORT[[type_dtp]]
    # Если ранжируем типы по факторам
    else:
        # Выделение значимых типов ДТП для данного фактора (до 15 штук)
        locale_REPORT = REPORT.sort_values(factor_dtp, ascending=False)
        locale_REPORT = locale_REPORT[(locale_REPORT[factor_dtp] > 0)]
        if len(locale_REPORT) > count_alternatives:
            locale_REPORT = locale_REPORT[0:count_alternatives]
        locale_REPORT = locale_REPORT[[factor_dtp]]
    print(locale_REPORT)

    # Если нашлась только 1 альтернатива
    if len(locale_REPORT) == 1:
        result_table = pd.DataFrame()
        alternatives_list = locale_REPORT.index.tolist()
        result_table.index = [0]
        result_table = adding_columns(result_table, ['Альтернатива', 'Приоритет, %', 'Ранг'])
        for ind, row in enumerate(alternatives_list):
            result_table.loc[ind, 'Альтернатива'] = row
            result_table.loc[ind, 'Приоритет, %'] = 100
            result_table.loc[ind, 'Ранг'] = '1'
        return result_table

    # Матрица оценок альтернатив
    locale_REPORT_index = locale_REPORT.index.tolist()
    alternatives_matrix = pd.DataFrame()
    alternatives_matrix.index = locale_REPORT_index
    alternatives_matrix = adding_columns(alternatives_matrix, criteria_keys)
    for key in criteria_keys:
        for alternative in locale_REPORT_index:
            # Если ранжируем факторы по типам
            if not (type_dtp is None):
                if key == 'Тип ДТП':
                    alternatives_matrix.loc[alternative, key] = locale_REPORT.loc[alternative, type_dtp]
                else:
                    alternatives_matrix.loc[alternative, key] = count_alternatives_by_criterion(key, LOCAL_DATA,
                                                                                                factor_dtp=alternative)
            # Если ранжируем типы по факторам
            else:
                if key == 'Фактор ДТП':
                    alternatives_matrix.loc[alternative, key] = locale_REPORT.loc[alternative, factor_dtp]
                else:
                    alternatives_matrix.loc[alternative, key] = count_alternatives_by_criterion(key, LOCAL_DATA,
                                                                                                type_dtp=alternative)

    # Матрицы попарных сравнений альтернатив по критериям
    matrix_of_alternatives = []
    for key in criteria_keys:
        matrix_of_alternatives.append(create_matrix_of_pairwise_comparisons(alternatives_matrix[key].tolist()))

    # Расчет НВП, индекса солгасования и отношения согласования матрицы критериев
    nvp_criteria_matrix, approval_index_criteria, consistency_relation_criteria = \
        calculate_matrix_of_pairwise_comparisons(criteria_matrix)
    print(consistency_relation_criteria)

    # НВП матриц альтернатив по критериям
    nvp_matrix_alternatives = []
    # Индексы согласования матриц альтернатив по критериям
    approval_index_alternatives = []
    # Отношения согласования матриц альтернатив по критериям
    consistency_relation_alternatives = []
    for matrix in matrix_of_alternatives:
        nvp_matrix, approval_index, consistency_relation = calculate_matrix_of_pairwise_comparisons(matrix)
        nvp_matrix_alternatives.append(nvp_matrix)
        approval_index_alternatives.append(approval_index)
        consistency_relation_alternatives.append(consistency_relation)
    print(consistency_relation_alternatives)

    # МАИ
    priority_values = []
    for alternative_index in range(0, len(nvp_matrix_alternatives[0])):
        temp_priority_value = 0
        for criteria_index in range(0, len(nvp_matrix_alternatives)):
            temp_priority_value += nvp_matrix_alternatives[criteria_index][alternative_index] * nvp_criteria_matrix[
                criteria_index]
        priority_values.append(temp_priority_value)
    sum_priority_values = sum(priority_values)
    for ind in range(0, len(priority_values)):
        priority_values[ind] /= sum_priority_values

    # Расчет обобщенного отношения согласованности
    generalized_approval_index = 0
    for ind, approval_index in enumerate(approval_index_alternatives):
        generalized_approval_index += approval_index * nvp_criteria_matrix[ind]
    temp_pss_value = get_pss_value(len(nvp_matrix_alternatives[0]))
    if temp_pss_value != 0:
        generalized_consistency_relation = generalized_approval_index / temp_pss_value
    else:
        generalized_consistency_relation = 0
    print(generalized_consistency_relation)

    # ММАИ
    result_estimates = mmai(nvp_matrix_alternatives, nvp_criteria_matrix)
    print(priority_values)
    print(result_estimates)

    # Создание таблицы результатов
    result_table = pd.DataFrame()
    alternatives_list = alternatives_matrix.index.tolist()
    result_table.index = [i for i in range(len(result_estimates))]
    result_table = adding_columns(result_table, ['Альтернатива', 'Приоритет, %', 'Ранг'])
    for ind, row in enumerate(alternatives_list):
        result_table.loc[ind, 'Альтернатива'] = row
        result_table.loc[ind, 'Приоритет, %'] = result_estimates[ind] * 100
    result_table = result_table.sort_values('Приоритет, %', ascending=False)
    rang = 1
    temp_priority = 0
    for ind, row in result_table.iterrows():
        if temp_priority == row['Приоритет, %']:
            result_table.loc[ind, 'Ранг'] = str(rang - 1)
        else:
            result_table.loc[ind, 'Ранг'] = str(rang)
            temp_priority = row['Приоритет, %']
            rang += 1
    for ind, row in result_table.iterrows():
        result_table.loc[ind, 'Приоритет, %'] = round(row['Приоритет, %'], 2)
    return result_table
