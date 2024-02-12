dic = {}
line = input().split(maxsplit=1)
while line != ['END']:
    if len(line) == 1:
        dic.setdefault(line[0], 'Unknown Name')
    else:
        dic.setdefault(line[0], line[1])
    line = input().split(maxsplit=1)
print(dic)

boss = input()
new_dic = dic.copy()
if ' ' in boss:
    for key,value in dic.items():
        if value == boss:
            del new_dic[key]  
else: 
    del new_dic[boss]

sorted_dic = sorted(new_dic.items(), key = lambda item: item[0])
print(sorted_dic)  
