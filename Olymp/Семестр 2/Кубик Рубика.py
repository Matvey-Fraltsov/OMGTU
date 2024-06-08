with open(r'Кубик Рубика\input_s1_01.txt') as f:
    lines = f.readlines()

n, m = map(int, lines[0].split())
x, y, z = map(int, lines[1].split())

for line in lines[2:m+2]:
    step = line.split()
    dim, pos, orientation = step[0], int(step[1]), int(step[2])

    if dim == "X" and x == pos:
        if orientation == 1:
            z, y = n+1-y, z
        else:
            y, z = n+1-z, y
    elif dim == "Y" and y == pos:
        if orientation == 1:
            z, x = n+1-x, z
        else:
            x, z = n+1-z, x
    elif dim == "Z" and z == pos:
        if orientation > 0:
            y, x = n+1-x, y
        else:
            x, y = n+1-y, x

print(x, y, z)
