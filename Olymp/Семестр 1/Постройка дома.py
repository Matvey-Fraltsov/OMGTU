for i in range(1, 15):
    num = '0' + str(i) if len(str(i)) == 1 else str(i)
    with open(f'Постройка дома/input_s1_{num}.txt') as f:
        input_data = f.read()
        data = [int(x) for x in input_data.split()]
    with open(f'Постройка дома/output_s1_{num}.txt') as f:
        output_data = int(f.read())

    x, y, l, c1, c2, c3, c4, c5, c6 = data
    cost = 0
    trash = 0
    p = 2 * (x + y)

    wall_remainder = l - max(x, y)
    wall_base = l

    if l > p:
        trash = (l - p) * (c2 + c6)
        wall_base -= (l - p)
        wall_remainder -= (l - p)
        l = p
    if wall_remainder <= 0:
        if c1 < (c2 + c4 + c5 + c6):
            if c1 < (c2 + c3):
                cost = wall_base * c1 + (p - l) * (c4 + c5)
            else:
                cost = wall_base * (c2 + c3) + (p - l) * (c4 + c5)
        else:
            cost = wall_base * (c2 + c6) + p * (c4 + c5)
    else:
        if c1 < (c2 + c4 + c5 + c6):
            if c3 < (c4 + c5 + c6):
                if c1 < (c2 + c3):
                    cost = (wall_base - wall_remainder) * c1 + wall_remainder * (c2 + c3) + (p - l) * (c4 + c5)
                else:
                    cost = (wall_base - wall_remainder) * (c2 + c3) + wall_remainder * (c2 + c3) + (p - l) * (c4 + c5)
            else:
                if c1 < (c2 + c3):
                    cost = (wall_base - wall_remainder) * c1 + wall_remainder * (c2 + c6) + (p - l + wall_remainder) * (
                            c4 + c5)
                else:
                    cost = (wall_base - wall_remainder) * (c2 + c3) + wall_remainder * (c2 + c6) + (
                            p - l + wall_remainder) * (c4 + c5)
        else:
            cost = wall_base * (c2 + c6) + p * (c4 + c5)

    result = cost + trash
    print(f'\n★Тест #{i}\nВходные данные:\n{input_data}\n'
          f'Предполагаемый результат: {output_data}\nВыходные данные: {result}')
