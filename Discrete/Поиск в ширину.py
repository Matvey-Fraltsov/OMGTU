from collections import deque


def bfs(graph, start):
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


# Пример графа заданного матрицей смежности
graph = [
    [0, 0, 0, 0, 0, 0],
    [0, 1, 0, 0, 0, 0],
    [1, 0, 0, 1, 0, 0],
    [0, 0, 1, 0, 1, 0],
    [1, 1, 1, 1, 0, 1],
    [1, 0, 1, 0, 1, 0],
]

start_node = 5
print("BFS trversal starting from node", start_node)
bfs(graph, start_node)
