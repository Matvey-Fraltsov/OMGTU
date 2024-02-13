from math import inf


def minimum(D, U):
    dm = (inf, -1, -1)
    for u in U:
        dd = min(D, key=lambda x: x[0] if (x[1] == u or x[2] == u) and (x[1] not in U or x[2] not in U) else inf)
        if dm[0] > dd[0]:
            dm = dd

    return dm


data, stop = [(inf, -1, -1)], False
while not stop:
    data.append((int(input('Вес: ')), int(input('Первая вершина: ')), int(input('Вторая вершина: '))))
    stop = int(input('Остановить ввод?\n1 - Да\n0 - Нет\n'))
Vert, Union, Result = int(input('Введите количество вершин: ')), {1}, []

while len(Union) < Vert:
    r = minimum(data, Union)
    if r[0] == inf:
        break

    Result.append(r)
    Union.add(r[1])
    Union.add(r[2])

summer = 0
for i in Result:
    summer += i[0]

print(summer)
