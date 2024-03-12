from datetime import date

for i in range(1, 9):
    with open(f'Интенсификация производства/input_s1_{"0" + str(i)}.txt') as f:
        input_data = f.read().splitlines()
    with open(f'Интенсификация производства/output_s1_{"0" + str(i)}.txt') as f:
        output_data = int(f.read())
    start = date(*[int(i) for i in input_data[0].split('.')][::-1])
    end = date(*[int(i) for i in input_data[1].split('.')][::-1])
    product_start, product_total = int(input_data[-1]), 0
    for j in range((end - start).days + 1):
        product_total += product_start
        product_start += 1
    input_data = '\n'.join(input_data)
    print(f'\n★Тест #{i}\nВходные данные:\n{input_data}\n'
          f'Предполагаемый результат: {output_data}\nВыходные данные: {product_total}')
