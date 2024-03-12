from math import inf

vert = int(input('Введите количество вершин: '))
counter = 0
matrix = [[0] * vert for _ in range(vert)]
for i in range(len(matrix[0])):
    matrix[i] = [int(i) for i in input().split()]
print('\t┃\t' + '\t'.join([str(i) for i in range(1, len(matrix[0]) + 1)]))
print('━━━━╋━' + '━' * (vert * 4))
for i in range(len(matrix[0])):
    print(i + 1, end='\t┃\t')
    for j in range(len(matrix[0])):
        print(matrix[i][j], end='\t')
    print()


def dijkstra(matrix, start, end):
    n = len(matrix)
    dist = [inf] * n
    dist[start] = 0
    visited = [False] * n
    path = [-1] * n

    for _ in range(n):
        u = min((dist[i], i) for i in range(n) if not visited[i])[1]
        visited[u] = True

        for v in range(n):
            if matrix[u][v] > 0 and not visited[v]:
                if dist[v] > dist[u] + matrix[u][v]:
                    dist[v] = dist[u] + matrix[u][v]
                    path[v] = u

    shortest_path = []
    end_vertex = end - 1
    while end_vertex != -1:
        shortest_path.insert(0, end_vertex)
        end_vertex = path[end_vertex]

    return dist[end - 1], shortest_path


start = int(input(f"Введите начальную вершину (от 1 до {vert}): "))
end = int(input(f"Введите конечную вершину (от 1 до {vert}): "))

result_dist, result_path = dijkstra(matrix, start - 1, end)

print("Кратчайшее расстояние от вершины", start, "до вершины", end, ":", result_dist)
print("Кратчайший путь:", " -> ".join([str(vertex + 1) for vertex in result_path]))
