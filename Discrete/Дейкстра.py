from math import inf

vert = int(input('Введите количество вершин: '))
counter = 0
matrix = [[0] * vert for _ in range(vert)]
for i in range(len(matrix[0])):
    matrix[i] = [int(i) for i in input().split()]
print('\t┃\t' + '\t'.join([str(i) for i in range(1, len(matrix[0]) + 1)]))
print('━━━━╋━' + '━' * (vert * 4))
for i in range(len(matrix[0])):
    print(i + 1, end='\t┃\t')
    for j in range(len(matrix[0])):
        print(matrix[i][j], end='\t')
    print()


print('\n', matrix)
