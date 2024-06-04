def branch_and_bound(graph, start=1):
    all_nodes = list(range(1, len(graph)+1))
    all_nodes.remove(start)
    min_path = float('inf')
    min_path_order = None

    def search(node, visited, path, cost):
        nonlocal min_path, min_path_order
        if len(visited) == len(all_nodes) + 1:
            if graph[node-1][start-1] != 0 and cost + graph[node-1][start-1] < min_path:
                min_path = cost + graph[node-1][start-1]
                min_path_order = [node] + path + [node]
            return

        for next_node in all_nodes:
            if next_node not in visited and graph[node-1][next_node-1] != 0:
                search(next_node, visited.union({next_node}), path + [node], cost + graph[node-1][next_node-1])

    search(start, {start}, [], 0)

    return min_path, min_path_order

graph = [
    [0, 5, 4, 2, 11],
    [12, 0, 11, 13, 10],
    [6, 4, 0, 7, 10],
    [4, 3, 5, 0, 12],
    [4, 2, 3, 5, 0],
]

min_path, min_path_order = branch_and_bound(graph)
print(f"Минимальный путь: {min_path}")
print(f"Путь: {min_path_order}")
