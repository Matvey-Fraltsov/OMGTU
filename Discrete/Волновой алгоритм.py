from collections import deque

def wave_algorithm(maze, start, end):
    directions = [(1, 0), (-1, 0), (0, 1), (0, -1)]
    queue = deque([(start[0], start[1], 0)])
    visited = set()

    while queue:
        x, y, dist = queue.popleft()
        if (x, y) == end:
            return dist

        if (x, y) in visited or maze[x][y] == '|':
            continue

        visited.add((x, y))

        for dx, dy in directions:
            new_x, new_y = x + dx, y + dy
            if 0 <= new_x < len(maze) and 0 <= new_y < len(maze[0]):
                queue.append((new_x, new_y, dist + 1))

    return False

maze = [
    ['0', '0', '0', '|', '0', '0'],
    ['0', '|', '0', '|', '0', '0'],
    ['0', '|', '0', '0', '0', '0'],
    ['0', '0', '|', '0', '|', '0'],
    ['0', '|', '0', '0', '0', '0'],
    ['0', '0', '0', '|', '|', '0'],
]

start = (0, 0)
end = (5, 5)

result = wave_algorithm(maze, start, end)
if result:
    print(f"Кратчайшее расстояние от начала до конца: {result}")
else:
    print("Путь не найден")
