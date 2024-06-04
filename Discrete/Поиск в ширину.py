from collections import deque


def BFS(graph, start):
    visited = [False] * len(graph)
    queue = deque([start])
    visited[start] = True

    while queue:
        node = queue.popleft()
        print(node, end=' ')

        for neighbor, is_connected in enumerate(graph[node]):
            if is_connected and not visited[neighbor]:
                queue.append(neighbor)
                visited[neighbor] = True


graph = [
    [0, 0, 0, 0, 0, 0],
    [0, 1, 0, 0, 0, 0],
    [1, 0, 0, 1, 0, 0],
    [0, 0, 1, 0, 1, 0],
    [1, 1, 1, 1, 0, 1],
    [1, 0, 1, 0, 1, 0],
]

start_node = 0
print("Обход в ширину из вершины:", start_node)
BFS(graph, start_node)
