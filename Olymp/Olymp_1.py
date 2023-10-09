res = []
for i in range(int(input())):
    pack = [float(i) for i in input().split()]
    s_1 = 2 * ((pack[0] * pack[1]) + (pack[1] * pack[2]) + (pack[2] * pack[0]))
    s_2 = 2 * ((pack[3] * pack[4]) + (pack[4] * pack[5]) + (pack[3] * pack[5]))
    v_1 = pack[0] * pack[1] * pack[2] / 1000
    v_2 = pack[3] * pack[4] * pack[5] / 1000
    price_1, price_2= pack[6], pack[7]
    res.append(round((price_1 * s_2 - price_2 * s_1) / (v_1 * s_2 - v_2 * s_1),2))
print(res.index(min(res)) + 1, format(min(res), '.2f'))