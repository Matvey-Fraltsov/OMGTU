class Graph:
    def __init__(self, vertex): #конструктор
        self.V = vertex
        self.graph = []

    def add_edge(self, u, v, w): #добавление ребра (вершина 0 (1), вершина 1 (2), вес)
        self.graph.append([u, v, w])

    def search(self, parent, i): #поиск родителя вершины
        if parent[i] == i:
            return i
        return self.search(parent, parent[i])

    def apply_union(self, parent, rank, x, y): #объединение множеств
        xroot = self.search(parent, x)
        yroot = self.search(parent, y)
        if rank[xroot] < rank[yroot]:
            parent[xroot] = yroot
        elif rank[xroot] > rank[yroot]:
            parent[yroot] = xroot
        else:
            parent[yroot] = xroot
            rank[xroot] += 1

    def kruskal(self): #алгоритм Краскала (Крускала)
        result = []
        i, e = 0, 0 #счетчик ребер и добавленных ребер
        self.graph = sorted(self.graph, key=lambda item: item[2])
        parent = []
        rank = []
        for node in range(self.V):
            parent.append(node)
            rank.append(0)
        while e < self.V - 1:
            u, v, w = self.graph[i]
            i = i + 1
            x = self.search(parent, u)
            y = self.search(parent, v)
            if x != y:
                e = e + 1
                result.append([u, v, w])
                self.apply_union(parent, rank, x, y)
        finish_sum = 0
        for u, v, weight in result:
            print("Ребро:", u,"-", v, "=", weight)
            finish_sum += weight
        print("Сумма ребёр полученного дерева: " + str(finish_sum))

print("Задание 1 - изображение:")
#Граф из 7 вершин (от 0 до 6)
g = Graph(7)

#вершина 1
g.add_edge(0, 1, 4)
g.add_edge(0, 3, 3)
g.add_edge(0, 4, 6)
g.add_edge(0, 5, 1)

#вершина 2
g.add_edge(1, 2, 2)
g.add_edge(1, 3, 3)
g.add_edge(1, 4, 7)
g.add_edge(1, 5, 6)
g.add_edge(1, 6, 1)

#вершина 3
g.add_edge(2, 4, 4)
g.add_edge(2, 6, 2)

#вершина 4
g.add_edge(3, 4, 1)
g.add_edge(3, 5, 5)
g.add_edge(3, 6, 3)

#вершина 5
g.add_edge(4, 5, 3)
g.add_edge(4, 6, 6)

#вершина 6
g.add_edge(5, 6, 7)

#ребра из вершины 7 уже были перечислены в вершинах 1-6
g.kruskal()

print('')
print("Задание 2 - таблица:")
#Граф из 9 вершин - от 0 до 8
graph = Graph(9)

#вершина 1
graph.add_edge(0,1,15) #1 - 2 - 15
graph.add_edge(0,4,14) #1 - 5 - 14
graph.add_edge(0,3,23) #1 - 4 - 23

#вершина 2
graph.add_edge(1,2,19) #2 - 3 - 19
graph.add_edge(1,3,16) #2 - 4 - 16
graph.add_edge(1,4,15) #2 - 5 - 15

#вершина 3
graph.add_edge(2,4,14) #3 - 5 - 14
graph.add_edge(2,5,26) #3 - 6 - 26

#вершина 4
graph.add_edge(3,4,25) #4 - 5 - 25
graph.add_edge(3,6,23) #4 - 7 - 23
graph.add_edge(3,7,20) #4 - 8 - 20

#вершина 5
graph.add_edge(4,5,24) #5 - 6 - 24
graph.add_edge(4,7,27) #5 - 8 - 27
graph.add_edge(4,8,18) #5 - 9 - 18


#вершина 7
graph.add_edge(6,7,14) #7 - 8 - 14

#вершина 8
graph.add_edge(7,8,18) #8 - 9 - 18

graph.kruskal()
