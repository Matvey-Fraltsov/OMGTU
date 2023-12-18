N, i, s = int(input()), 1, 0
while 2**i - 1 <= N:
    s += N // (2**i - 1)
    i += 1
print(s)