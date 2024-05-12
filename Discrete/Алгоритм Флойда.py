from math import inf

def floyd_algorithm(graph):
    n = len(graph)
    dist = [[inf] * n for _ in range(n)]
    next_vertex = [[None] * n for _ in range(n)]

    for i in range(n):
        for j in range(n):
            if graph[i][j] != inf:
                dist[i][j] = graph[i][j]
                next_vertex[i][j] = j

    for k in range(n):
        for i in range(n):
            for j in range(n):
                if dist[i][k] + dist[k][j] < dist[i][j]:
                    dist[i][j] = dist[i][k] + dist[k][j]
                    next_vertex[i][j] = next_vertex[i][k]

    return dist, next_vertex


def restore_path(next_vertex, distances, i, j):
    if i == j or next_vertex[i][j] is None:
        return None, None
    path = [i + 1]
    dist = distances[i][j]
    while i != j:
        i = next_vertex[i][j]
        path.append(i + 1)
    return path, dist


def restore_all_paths(next_vertex, distances):
    n = len(next_vertex)
    all_paths = [[[None, None] for _ in range(n)] for _ in range(n)]
    for i in range(n):
        for j in range(n):
            all_paths[i][j] = restore_path(next_vertex, distances, i, j)
    return all_paths


graph = [
            [0, 5, inf, 10],
            [inf, 0, 3, inf],
            [inf, inf, 0, 1],
            [inf, inf, inf, 0]
        ]

distances, next_vertex = floyd_algorithm(graph)

all_paths = restore_all_paths(next_vertex, distances)

print("\nКратчайшие пути для всех пар вершин:")
for i in range(len(all_paths)):
    for j in range(len(all_paths[i])):
        path, dist = all_paths[i][j]
        if path is not None:
            print(f"Из {i + 1} в {j + 1}: путь: {path} <-- расстояние: {dist}")
