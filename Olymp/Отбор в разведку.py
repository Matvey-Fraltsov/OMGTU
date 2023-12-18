for i in range(1, 11):
    if i < 10:
        i = '0' + str(i)
    with open(f'Отбор в разведку/input_s1_{i}.txt') as f:
        input_soldiers = int(f.read())
    with open(f'Отбор в разведку/output_s1_{i}.txt') as f:
        output_line = int(f.read())

    count = 0
    if input_soldiers >= 3:
        line = 1
        while line <= input_soldiers / 2:
            line *= 2
        if input_soldiers <= line + line / 2:
            count = input_soldiers - line
        else:
            count = 2 * line - input_soldiers
    print(f'\n★Тест #{i}\nВходные данные:\n{input_soldiers}\n'
          f'Предполагаемый результат: {output_line}\nВыходные данные: {count}')
