def is_valid(v, graph, path, pos):
    if graph[path[pos - 1]][v] == 0:
        return False

    for vertex in path:
        if vertex == v:
            return False

    return True


def hamilton_cycle_util(graph, path, pos):
    if pos == len(graph):
        if graph[path[pos - 1]][path[0]] == 1:
            return True
        else:
            return False

    for v in range(1, len(graph)):
        if is_valid(v, graph, path, pos):
            path[pos] = v

            if hamilton_cycle_util(graph, path, pos + 1):
                return True

            path[pos] = -1

    return False


def hamilton_cycle(graph):
    path = [-1] * len(graph)
    path[0] = 0

    if not hamilton_cycle_util(graph, path, 1):
        print("Гамильтонов цикл отсутствует")
        return False

    print("Гамильтонов цикл:")
    for vertex in path:
        print(vertex, end=' ')
    print(path[0])
    return True


graph = [
    [0, 1, 0, 1, 0],
    [1, 0, 1, 1, 1],
    [0, 1, 0, 0, 1],
    [1, 1, 0, 0, 1],
    [0, 1, 1, 1, 0]
]

hamilton_cycle(graph)
