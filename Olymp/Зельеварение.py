#DUST root tooth
#WATER 1 tear

class Zelie:
    def __init__(self):
        self.data = []
        self.magic = []

    def MIX(self, *args):
        for i in args:
            if type(i) == int:
                i = self.data[i - 1]
            self.magic.append(i)
        self.data.append(f"MX{(''.join(self.magic)).replace(' ', '')}XM")
        self.magic.clear()

    def WATER(self, *args):
        magic = []
        for i in args:
            if type(i) == int:
                i = self.data[i - 1]
            self.magic.append(i)
        self.data.append(f"WT{(''.join(self.magic)).replace(' ', '')}TW")
        self.magic.clear()

    def DUST(self, *args):
        magic = []
        for i in args:
            if type(i) == int:
                i = self.data[i - 1]
            self.magic.append(i)
        self.data.append(f"DT{(''.join(self.magic)).replace(' ', '')}TD")
        self.magic.clear()

    def FIRE(self, *args):
        magic = []
        for i in args:
            if type(i) == int:
                i = self.data[i - 1]
            self.magic.append(i)
        self.data.append(f"FR{(''.join(self.magic)).replace(' ', '')}RF")
        self.magic.clear()



x = Zelie()
x.DUST('XqK', 'DWYMfDBZ', 'ZZdnlqo')
x.FIRE(1, 'Odg')
x.WATER(1)
x.MIX(3, 2, 'xJZYkKXL')
x.DUST(4, 'ceeJr')
print(x.data[-1])
