from math import inf


def ford_bellman(graph, start):
    V = len(graph)
    dist = [inf] * V
    dist[start - 1] = 0
    prev = [-1] * V

    for i in range(V - 1):
        for u in range(V):
            for v in range(V):
                if graph[u][v] != inf:
                    if dist[u] + graph[u][v] < dist[v]:
                        dist[v] = dist[u] + graph[u][v]
                        prev[v] = u

    for u in range(V):
        for v in range(V):
            if graph[u][v] != inf:
                if dist[u] + graph[u][v] < dist[v]:
                    return "Граф содержит отрицательный цикл"

    return dist, prev


def build_path(prev, end):
    path = []
    current = end
    while current != -1:
        path.insert(0, current + 1)
        current = prev[current]

    return path


graph = [
    [0, -5, inf, 10],
    [inf, 0, 3, inf],
    [inf, inf, 0, 1],
    [inf, inf, inf, 0]
]

start = 1
distances, predecessors = ford_bellman(graph, start)

for i, d in enumerate(distances):
    if d != inf:
        path = build_path(predecessors, i)
        print(f'Кратчайший путь от вершины {start} до вершины {i + 1}: {" -> ".join(map(str, path))}, расстояние = {d}')
    else:
        print(f'От вершины {start} до вершины {i + 1} нет пути')
