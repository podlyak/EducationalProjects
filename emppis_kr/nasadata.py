import random
import copy

data = [[2.2, 8.4], [3.5, 10.8], [5.5, 18], [6, 24], [9.7, 25.2], [7.7, 31.2], [11/3, 36], [8.2, 36], [6.5, 42],
        [8, 42], [20, 48], [10, 48], [15, 48], [10.4, 50], [13, 60], [14, 60], [19.7, 60], [32.5, 60], [31.5, 60],
        [12.5, 62], [15.4, 70], [20, 72], [7.5, 72], [16.3, 82], [15, 90], [11.4, 98.8], [21, 107], [16, 114],
        [25.9, 117.6], [24.6, 117.6], [29.5, 120], [19.3, 155], [32.6, 170], [35.5, 192], [38, 210], [48.5, 239],
        [47.5, 252], [70, 278], [66.6, 300], [66.6, 352.8], [50, 370], [79, 400], [90, 450], [78, 571.4], [100, 215],
        [150, 324], [100, 360], [100, 360], [190, 420], [115.8, 480], [101, 750], [161.1, 815], [284.7, 973],
        [227, 1181], [177.9, 1228], [282.1, 1368], [219, 2120], [423, 2300], [302, 2400], [370, 3240]]


class Project:
    def __init__(self, length, cost):
        self.length = float(length)
        self.cost = float(cost)


class Projects:
    def __init__(self, projects):
        self.projects = copy.deepcopy(projects)

    def sort(self):
        for i in range(len(self.projects) - 1):
            for j in range(i + 1, len(self.projects)):
                if self.projects[i].length > self.projects[j].length \
                        or self.projects[i].length == self.projects[j].length \
                        and self.projects[i].cost > self.projects[j].cost:
                    self.projects[i], self.projects[j] = self.projects[j], self.projects[i]


class NasaProjects:
    def __init__(self):
        input_projects = []
        for val in data:
            input_projects.append(Project(val[0], val[1]))
        self.main_sample = Projects(input_projects)
        random.shuffle(input_projects)
        slice_point = int(len(input_projects) * 1 / 3)
        self.train_sample = Projects(input_projects[:slice_point])
        self.test_sample = Projects(input_projects[slice_point:])
        self.main_sample.sort()
        self.test_sample.sort()
        self.train_sample.sort()

    def get_calculated_cost(self, a, b):
        for project in self.test_sample.projects:
            yield a * project.length**b

    def get_test_cost(self):
        for project in self.test_sample.projects:
            yield project.cost

    def get_test_length(self):
        for project in self.test_sample.projects:
            yield project.length
