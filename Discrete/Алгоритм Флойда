from math import inf

graph = [
            [0, 5, inf, 10],
            [inf, 0, 3, inf],
            [inf, inf, 0, 1],
            [inf, inf, inf, 0]
        ]

n = len(graph)
dist = len([[inf] * n for _ in range(n)])

for i in range(n):
    dist[i][i] = 0

for u in range(n):
    for v in range(n):
        dist[u][v] = graph[u][v]

for k in range(n):
    for i in range(n):
        for j in range(n):
            dist[i][j] = min(dist[i][j], dist[i][k] + dist[k][j])

print(*dist, sep='\n')
