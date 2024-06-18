with open('Игра Города/input_s1_04.txt') as f:
    data = f.read().splitlines()

answer = []
while len(data) > 1:
    graph = {}
    nodes = []
    result = []
    path = []
    vertex_stack = []
    edge_stack = []

    nodes_set = set()
    for word in data:
        nodes_set.add(word[0])
        nodes_set.add(word[-1])

    nodes = list(nodes_set)

    for sym in nodes:
        lst = []
        for word in data:
            if word[0] == sym or word[-1] == sym:
                lst.append(word)
        graph[sym] = lst

    start_node = nodes[0]
    vertex_stack.append(start_node)
    while vertex_stack:
        cur_edge_list = graph[vertex_stack[-1]].copy()
        if len(cur_edge_list) > 0:
            edge_stack.append(cur_edge_list[0])
            cur_edge_list.pop(0)
            graph[vertex_stack[-1]] = cur_edge_list
            cur_node = edge_stack[-1][-1]
            vertex_stack.append(cur_node)
        else:
            path.append(vertex_stack.pop())
            if len(edge_stack) > 0:
                result.append(edge_stack.pop())
    result.reverse()
    i = 0
    result_dict = {k: i for k in result}
    for key in result_dict.keys():
        data.pop(data.index(key))
    if result_dict:
        answer.append(len(result_dict))

answer.sort(reverse=True)
print(len(answer))
for q in answer:
    print(q)
