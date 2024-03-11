class Potion:
    def __init__(self):
        self.data = []
        self.magic = []

    def mix(self, args):
        for i in args:
            if type(i) == int:
                i = self.data[i - 1]
            self.magic.append(i)
        self.data.append(f"MX{(''.join(self.magic)).replace(' ', '')}XM")
        self.magic.clear()

    def water(self, args):
        for i in args:
            if type(i) == int:
                i = self.data[i - 1]
            self.magic.append(i)
        self.data.append(f"WT{(''.join(self.magic)).replace(' ', '')}TW")
        self.magic.clear()

    def dust(self, args):
        for i in args:
            if type(i) == int:
                i = self.data[i - 1]
            self.magic.append(i)
        self.data.append(f"DT{(''.join(self.magic)).replace(' ', '')}TD")
        self.magic.clear()

    def fire(self, args):
        for i in args:
            if type(i) == int:
                i = self.data[i - 1]
            self.magic.append(i)
        self.data.append(f"FR{(''.join(self.magic)).replace(' ', '')}RF")
        self.magic.clear()


for test in range(1, 11):
    with open(f'Зельеварение/input{test}.txt') as f:
        inp = [i.split() for i in f.read().splitlines()]
    with open(f'Зельеварение/output{test}.txt') as f:
        out = f.read()

    x = Potion()
    for i in range(len(inp)):
        for j in range(len(inp[i])):
            try:
                inp[i][j] = int(inp[i][j])
            except ValueError:
                continue
        x.fire(inp[i][1:]) if inp[i][0] == "FIRE" else (x.mix(inp[i][1:]) if inp[i][0] == "MIX" else
                                                 (x.water(inp[i][1:]) if inp[i][0] == "WATER" else x.dust(inp[i][1:])))

    print(x.data[-1] == out)
