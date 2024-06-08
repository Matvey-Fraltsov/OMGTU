def decode_word(word):
    translated_w = ''
    plus = 1
    side = -1
    ind = len(word) // 2
    translated_w += word[ind]
    for i in range(len(word) - 1):
        translated_w += word[ind + plus * side]
        if i % 2 == 1:
            plus += 1
        side *= -1
    return translated_w


with open('Тау-Кита/input_s1_01.txt') as f:
    data = f.read().splitlines()

data = data[0].split()
earth_frase = []
pl = 1
sd = -1
index = len(data) // 2
earth_frase.append(decode_word(data[index]))
for i in range(len(data) - 1):
    earth_frase.append(decode_word(data[index + pl * sd]))
    if i % 2 == 1:
        pl += 1
    sd *= -1

print(' '.join(earth_frase))
