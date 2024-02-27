class Graph:
    def __init__(self, verticels):
        self.V = verticels + 1
        self.adjList = {}
        for i in range(1, self.V):
            self.adjList[i] = []

    def AddEdge(self,v,w):
        self.adjList[v].append(w)
        self.adjList[w].append(v)

    def Visit(self, v, visited):
        visited[v] = True
        print(v, end=' ')

        for i in self.adjList[v]:
            if not visited[i]:
                self.Visit(i, visited)

    def PrintComponents(self):
        visited = [False] * (self.V)

        for v in range(1, self.V):
            if not visited[v]:
                self.Visit(v, visited)
                print()
