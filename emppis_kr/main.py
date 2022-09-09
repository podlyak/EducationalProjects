import random
import numpy as np
import matplotlib.pyplot as plt
from bitarray import bitarray, util
import math
import copy

from nasadata import NasaProjects

nasa_projects = NasaProjects()
left_bound = -5
right_bound = 5
accuracy = 3


class Individual(object):

    def __init__(self, bit_size):
        self.bit_size = bit_size
        bits_a = format(random.getrandbits(self.bit_size), 'b')
        bits_b = format(random.getrandbits(self.bit_size), 'b')
        self.bit_array_a = bitarray(bits_a)
        self.bit_array_b = bitarray(bits_b)
        self.segment_a = None
        self.segment_b = None
        self.func_val = None
        self.a = 0
        self.b = 0
        self.refresh()

    def calculate_RMS(self):
        self.func_val = np.sqrt(np.sum([np.abs(project.cost - (self.a * project.length**self.b))
                                for project in nasa_projects.train_sample.projects])
                                / len(nasa_projects.train_sample.projects))

    def refresh(self):
        self.segment_a = util.ba2int(self.bit_array_a)
        self.segment_b = util.ba2int(self.bit_array_b)
        self.a = left_bound + self.segment_a * ((right_bound - left_bound) / (2 ** self.bit_size - 1))
        self.b = left_bound + self.segment_b * ((right_bound - left_bound) / (2 ** self.bit_size - 1))
        self.calculate_RMS()

    def cross_with_a(self, ind_2):
        if len(self.bit_array_a) <= len(ind_2.bit_array_a):
            cross_point_1 = random.randint(0, len(self.bit_array_a) - 2)
            cross_point_2 = random.randint(cross_point_1 + 1, len(self.bit_array_a) - 1)
        else:
            cross_point_1 = random.randint(0, len(ind_2.bit_array_a) - 2)
            cross_point_2 = random.randint(cross_point_1 + 1, len(ind_2.bit_array_a) - 1)
        my_mid = ind_2.bit_array_a[cross_point_1:cross_point_2]
        ind_2_mid = self.bit_array_a[cross_point_1:cross_point_2]
        self.bit_array_a[cross_point_1:cross_point_2] = my_mid
        ind_2.bit_array_a[cross_point_1:cross_point_2] = ind_2_mid
        self.refresh()
        ind_2.refresh()

    def cross_with_b(self, ind_2):
        if len(self.bit_array_b) <= len(ind_2.bit_array_b):
            cross_point_1 = random.randint(0, len(self.bit_array_b) - 2)
            cross_point_2 = random.randint(cross_point_1 + 1, len(self.bit_array_b) - 1)
        else:
            cross_point_1 = random.randint(0, len(ind_2.bit_array_b) - 2)
            cross_point_2 = random.randint(cross_point_1 + 1, len(ind_2.bit_array_b) - 1)
        my_mid = ind_2.bit_array_b[cross_point_1:cross_point_2]
        ind_2_mid = self.bit_array_b[cross_point_1:cross_point_2]
        self.bit_array_b[cross_point_1:cross_point_2] = my_mid
        ind_2.bit_array_b[cross_point_1:cross_point_2] = ind_2_mid
        self.refresh()
        ind_2.refresh()

    def mutate_a(self):
        mutate_point = random.randint(0, len(self.bit_array_a) - 1)
        self.bit_array_a.invert(mutate_point)
        self.refresh()

    def mutate_b(self):
        mutate_point = random.randint(0, len(self.bit_array_b) - 1)
        self.bit_array_b.invert(mutate_point)
        self.refresh()


class Population(object):

    def __init__(
            self,
            population_size,
            crossing_over_prob,
            mutation_prob,
            bit_size
    ):
        self.individuals_list = []
        self.population_size = population_size
        self.crossing_over_prob = crossing_over_prob
        self.mutation_prob = mutation_prob
        self.bit_size = bit_size

    def init_population(self):
        self.individuals_list = [Individual(self.bit_size) for _ in range(self.population_size)]
        self.sort_population()

    def sort_population(self):
        self.individuals_list.sort(key=lambda individual: individual.func_val)

    def get_2_args_func(self):
        x = []
        y = []
        z = []
        for individual in self.individuals_list:
            x.append(individual.a)
            y.append(individual.b)
            z.append(individual.func_val)
        return x, y, z

    def evolution(self):
        self.reproduction()
        self.crossing_over()
        self.mutation()

    def reproduction(self):
        individuals_list_new = []
        count = self.population_size
        individuals_list_new.append(self.individuals_list[0])
        count -= 1
        while count > 0:
            ind1 = random.randint(0, self.population_size - 1)
            ind2 = random.randint(0, self.population_size - 1)
            if self.individuals_list[ind1].func_val <= self.individuals_list[ind2].func_val:
                individuals_list_new.append(self.individuals_list[ind1])
            else:
                individuals_list_new.append(self.individuals_list[ind2])
            count -= 1
        self.individuals_list = individuals_list_new
        self.sort_population()

    def crossing_over(self):
        self.crossing_over_a()
        self.sort_population()
        self.crossing_over_b()
        self.sort_population()

    def crossing_over_a(self):
        individuals_list_new = []
        individuals_list_new.extend([self.individuals_list.pop(0), self.individuals_list.pop(1)])
        while len(self.individuals_list) > 0:
            parents = [self.individuals_list.pop(random.randint(0, len(self.individuals_list) - 1)) for _ in range(2)]
            parent_1 = copy.deepcopy(parents[0])
            parent_2 = copy.deepcopy(parents[1])
            if random.random() < self.crossing_over_prob:
                parent_1.cross_with_a(parent_2)
            individuals_list_new.extend([parent_1, parent_2])
        self.individuals_list = individuals_list_new

    def crossing_over_b(self):
        individuals_list_new = []
        individuals_list_new.extend([self.individuals_list.pop(0), self.individuals_list.pop(1)])
        while len(self.individuals_list) > 0:
            parents = [self.individuals_list.pop(random.randint(0, len(self.individuals_list) - 1)) for _ in range(2)]
            parent_1 = copy.deepcopy(parents[0])
            parent_2 = copy.deepcopy(parents[1])
            if random.random() < self.crossing_over_prob:
                parent_1.cross_with_b(parent_2)
            individuals_list_new.extend([parent_1, parent_2])
        self.individuals_list = individuals_list_new

    def mutation(self):
        self.mutation_a()
        self.sort_population()
        self.mutation_b()
        self.sort_population()

    def mutation_a(self):
        for i, individual in enumerate(self.individuals_list):
            if random.random() <= self.mutation_prob and i != 0:
                individual.mutate_a()

    def mutation_b(self):
        for i, individual in enumerate(self.individuals_list):
            if random.random() <= self.mutation_prob and i != 0:
                individual.mutate_b()

    def get_best(self):
        min_individual = self.individuals_list[0]
        for i in range(1, len(self.individuals_list)):
            if self.individuals_list[i].func_val < min_individual.func_val:
                min_individual = self.individuals_list[i]
        return min_individual.func_val, min_individual.a, min_individual.b


def main():
    print('\nEnter the parameters of GA')
    print('****************************************')
    population_size = int(input('Population size: '))
    crossing_over_prob = float(input('Crossing-over probability: '))
    mutation_prob = float(input('Mutation probability: '))
    global left_bound
    left_bound = float(input('Left bound of GA variables: '))
    global right_bound
    right_bound = float(input('Right bound of GA variables: '))
    global accuracy
    accuracy = int(input('Accuracy: '))
    total_population = int(input('Total amount of populations: '))
    print('****************************************')
    # population_size = 200
    # crossing_over_prob = 0.5
    # mutation_prob = 0.01
    # accuracy = 3
    # left_bound = 0
    # right_bound = 7
    # total_population = 200

    segments_size = (right_bound - left_bound) * 10 ** accuracy
    bit_size = math.ceil(math.log2(segments_size))

    population = Population(
        population_size,
        crossing_over_prob,
        mutation_prob,
        bit_size
    )
    population.init_population()

    cur_population = 0
    best_fitness_func_list = []
    while total_population > cur_population:
        population.evolution()
        best_fitness_func_list.append(population.get_best()[0])
        cur_population += 1
    print('\n')
    print('Best solution:')
    print('****************************************')
    func_val, a_param, b_param = population.get_best()
    print('Error function value: ', func_val)
    print('A-param value: ', a_param)
    print('B-param value: ', b_param)
    print('****************************************')

    calculated_cost = list(nasa_projects.get_calculated_cost(a_param, b_param))
    test_cost = list(nasa_projects.get_test_cost())
    test_length = list(nasa_projects.get_test_length())

    def format_output(val):
        return "%.2f" % val

    fig, ax = plt.subplots()
    ax.plot(test_length, calculated_cost, 'ro', label="Calculated cost")
    ax.plot(test_length, test_cost, 'bo', label="Actual cost")
    ax.set_xlabel('Length')
    ax.set_ylabel('Cost')
    ax.set_title('RMS: ' + format_output(func_val)
                 + '    a: ' + format_output(a_param)
                 + '    b: ' + format_output(b_param))
    ax.legend()
    ax.grid(True)

    error_list = [test - calculated for test, calculated in zip(test_cost, calculated_cost)]
    fig, ax1 = plt.subplots()
    ax1.plot(test_length, error_list, 'b-', label="Errors")
    ax1.set_xlabel('Length')
    ax1.set_ylabel('Error')
    ax1.set_title('Errors\' graph')
    ax1.legend()
    ax1.grid(True)

    fig, ax2 = plt.subplots()
    ax2.plot([x for x in range(1, total_population + 1)], best_fitness_func_list, 'b-', label="Fitness function")
    ax2.set_xlabel('Population')
    ax2.set_ylabel('RMS')
    ax2.set_title('RMS graph')
    ax2.legend()
    ax2.grid(True)

    plt.show()


if __name__ == '__main__':
    main()
