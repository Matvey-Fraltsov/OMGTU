def DFS(graph, start, visited=None):
    if visited is None:
        visited = set()
    visited.add(start)
    print(start, end=' ')

    for i, node in enumerate(graph[start]):
        if node and i not in visited:
            DFS(graph, i, visited)


graph = [
    [0, 1, 0, 0, 1],
    [1, 0, 1, 0, 0],
    [0, 1, 0, 1, 0],
    [0, 0, 1, 0, 1],
    [1, 0, 0, 1, 0]
]

start_node = 0
print("Обход в глубину из вершины:", start_node)
DFS(graph, start_node)
