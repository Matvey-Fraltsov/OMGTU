def length(x, y, z, x1, y1, z1):
    return ((x - x1) ** 2 + (y - y1) ** 2 + (z - z1) ** 2) ** 0.5


for i in range(1, 21):
    if i < 10:
        i = '0' + str(i)
    with open(f'Паук и муха/input_s1_{i}.txt') as f:
        input_coord = f.read().splitlines()

    with open(f'Паук и муха/output_s1_{i}.txt') as f:
        output = float(f.read())

    a, b, c = [int(i) for i in input_coord[0].split(" ")]
    Sx, Sy, Sz = [int(i) for i in input_coord[1].split(" ")]
    Fx, Fy, Fz = [int(i) for i in input_coord[2].split(" ")]

    input_coord = '\n'.join(input_coord)

    if Fx == 0:
        if Sx == 0:
            interval = length(Fx, Fy, Fz, Sx, Sy, Sz)
        if Sz == c:
            interval = length(Fy, Fz, 0, Sy, c + Sx, 0)
        if Sz == 0:
            interval = length(Fy, Fz, 0, Sy, -Sx, 0)
        if Sy == 0:
            interval = length(-Fy, Fz, 0, Sx, Sz, 0)
        if Sy == b:
            interval = length(Fy, Fz, 0, b + Sx, Sz, 0)
        if Sx == a:
            interval = min(length(-Fy, Fz, 0, a + Sx, Sz, 0),
                           length(Fy, Fz, 0, Sy, c - Sz + c + a, 0),
                           length(Fy, Fz, 0, Sy, -(a + Sz), 0),
                           length(Fy, Fz, 0, b + a + b - Sy, Sz, 0))
    if Fy == 0:
        if Sy == 0:
            interval = length(Fx, Fy, Fz, Sx, Sy, Sz)
        if Sx == 0:
            interval = length(Fx, Fz, 0, -Sy, Sz, 0)
        if Sz == 0:
            interval = length(Fx, Fz, 0, Sx, -Sy, 0)
        if Sz == c:
            interval = length(Fx, Fz, 0, Sx, c + Sy, 0)
        if Sx == a:
            interval = length(Fx, Fz, 0, a + Sy, Sz, 0)
        if Sy == b:
            interval = min(length(Fx, Fz, 0, Sx, c + b + c - Sz, 0),
                           length(Fx, Fz, 0, a + b + a - Sx, Sz, 0),
                           length(Fx, Fz, 0, -(b + Sx), Sz, 0),
                           length(Fx, Fz, 0, Sx, -(b + Sz), 0))
    if Fz == 0:
        if Sz == 0:
            interval = length(Fx, Fy, Fz, Sx, Sy, Sz)
        if Sx == 0:
            interval = length(Fy, -Fx, 0, Sy, Sz, 0)
        if Sy == 0:
            interval = length(Fx, -Fy, 0, Sx, Sz, 0)
        if Sx == a:
            interval = length(Fy, Fx, 0, Sy, a + Sz, 0)
        if Sy == b:
            interval = length(Fx, Fy, 0, Sx, b + Sz, 0)
        if Sz == c:
            interval = min(length(Fx, -Fy, 0, Sx, c + Sy, 0),
                           length(Fy, -Fx, 0, Sy, c + Sx, 0),
                           length(Fx, Fy, 0, Sx, b + c + b - Sy, 0),
                           length(Fy, Fx, 0, Sy, a + c + a - Sx, 0))
    if Fz == c:
        if Sz == c:
            interval = length(Fx, Fy, Fz, Sx, Sy, Sz)
        if Sx == 0:
            interval = length(Fy, c + Fx, 0, Sy, Sz, 0)
        if Sy == 0:
            interval = length(Fx, c + Fy, 0, Sx, Sz, 0)
        if Sy == b:
            interval = length(Fx, c + Fy, 0, Sx, c + b + c - Sz, 0)
        if Sx == a:
            interval = length(Fy, c + Fx, 0, Sy, c + a + c - Sz, 0)
        if Sz == 0:
            interval = min(length(Fy, c + Fx, 0, Sy, -Sx, 0),
                           length(Fx, c + Fy, 0, Sx, -Sy, 0),
                           length(Fy, c + Fx, 0, Sy, c + a + c + a - Sx, 0),
                           length(Fx, c + Fy, 0, Sx, c + b + c + b - Sy, 0))
    if Fy == b:
        if Sy == b:
            interval = length(Fx, Fy, Fz, Sx, Sy, Sz)
        if Sx == 0:
            interval = length(b + Fx, Fz, 0, Sy, Sz, 0)
        if Sz == 0:
            interval = length(b + Fx, Fz, 0, Sy, -Sx, 0)
        if Sz == c:
            interval = length(b + Fx, Fz, 0, Sy, c + Sx, 0)
        if Sx == a:
            interval = length(b + Fx, Fz, 0, b + a + b - Sy, Sz, 0)
        if Sy == 0:
            interval = min(length(Fx, c + b + c - Fz, 0, Sx, Sz, 0),
                           length(a + b + a - Fx, Fz, 0, Sx, Sz, 0),
                           length(Fx, -(b + Fz), 0, Sx, Sz, 0),
                           length(-(b + Fx), Fz, 0, Sx, Sz, 0))
    if Fx == a:
        if Sx == a:
            interval = length(Fx, Fy, Fz, Sx, Sy, Sz)
        if Sy == 0:
            interval = length(a + Fy, Fz, 0, Sx, Sz, 0)
            print(f'\n★Тест #{i}\nВходные данные:\n{input_coord}\n'
                  f'Предполагаемый результат: {output}\nВыходные данные: {interval:.3f}')
            continue
        if Sz == 0:
            interval = length(Fy, a + Fz, 0, Sy, Sx, 0)
        if Sz == c:
            interval = length(Fy, c + a + c - Fz, 0, Sy, c + Sx, 0)
        if Sy == b:
            interval = length(b + a + b - Fy, Fz, 0, b + Sx, Sz, 0)
        if Sx == 0:
            interval = min(length(Fy, c + a + c - Fz, 0, Sy, Sz, 0),
                           length(a + Fy, Fz, 0, -Sy, Sz, 0),
                           length(Fy, -(a + Fz), 0, Sy, Sz, 0),
                           length(b + a + b - Fy, Fz, 0, Sy, Sz, 0))

    print(f'\n★Тест #{i}\nВходные данные:\n{input_coord}\n'
          f'Предполагаемый результат: {output}\nВыходные данные: {interval:.3f}')