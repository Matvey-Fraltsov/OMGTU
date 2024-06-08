f = open(r"Отгадай число\input_s1_01.txt")
f1 = open(r"Отгадай число\output_s1_01.txt")
n = int(f.readline())
A = []
for j in range(n+1):
    s = f.readline().split()
    A.append(s)
A.reverse()
kol_x = 0
sum_chis = int(A[0][0])
A.pop(0)
for a in A:
    if a[0] == "+":
        if a[1] == "x":
            kol_x += 1
        else:
            sum_chis -= int(a[1])
    elif a[0] == "-":
        if a[1] == "x":
            kol_x -= 1
        else:
            sum_chis += int(a[1])
    elif a[0] == "*":
        sum_chis /= int(a[1])
        kol_x /= int(a[1])
kol_x += 1
print(f"Задуманное число: {round(sum_chis / kol_x)}")
