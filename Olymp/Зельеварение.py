class Zelie:
    def __init__(self):
        self.data = []
        self.magic = []

    def MIX(self, args):
        for i in args:
            if type(i) == int:
                i = self.data[i - 1]
            self.magic.append(i)
        self.data.append(f"MX{(''.join(self.magic)).replace(' ', '')}XM")
        self.magic.clear()

    def WATER(self, args):
        for i in args:
            if type(i) == int:
                i = self.data[i - 1]
            self.magic.append(i)
        self.data.append(f"WT{(''.join(self.magic)).replace(' ', '')}TW")
        self.magic.clear()

    def DUST(self, args):
        for i in args:
            if type(i) == int:
                i = self.data[i - 1]
            self.magic.append(i)
        self.data.append(f"DT{(''.join(self.magic)).replace(' ', '')}TD")
        self.magic.clear()

    def FIRE(self, args):
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

    x = Zelie()
    for i in range(len(inp)):
        for j in range(len(inp[i])):
            try:
                inp[i][j] = int(inp[i][j])
            except ValueError:
                continue
        x.FIRE(inp[i][1:]) if inp[i][0] == "FIRE" else (x.MIX(inp[i][1:]) if inp[i][0] == "MIX" else
                                                (x.WATER(inp[i][1:]) if inp[i][0] == "WATER" else x.DUST(inp[i][1:])))

    print(x.data[-1] == out)

