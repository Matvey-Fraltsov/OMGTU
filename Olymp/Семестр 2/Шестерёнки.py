def sign(value):
    return (value > 0) - (value < 0)

def process_input(input_file_path=None):
    with open(input_file_path, "r") as file:
        num_gears, num_connections = map(int, file.readline().strip().split())
        gears = [list(map(int, file.readline().strip().split())) for _ in range(num_gears)]
        connections = [list(map(lambda x: int(x) - 1, file.readline().strip().split())) for _ in range(num_connections)]
        gear_index_1, gear_index_2 = map(lambda x: int(x) - 1, file.readline().strip().split())
        velocity = int(file.readline().strip())

    gears.sort()
    connections.sort()
    gears[gear_index_1].append(velocity)

    for i in range(len(gears)):
        if i != gear_index_1:
            gears[i].append(0)

    for connection_1, connection_2 in connections:
        if gears[connection_1][2] != 0 and gears[connection_2][2] == 0:
            gears[connection_2][2] = -gears[connection_1][2] * gears[connection_1][1] / gears[connection_2][1]
        elif gears[connection_1][2] == 0 and gears[connection_2][2] != 0:
            gears[connection_1][2] = -gears[connection_2][2] * gears[connection_2][1] / gears[connection_1][1]
        elif gears[connection_1][2] != 0 and gears[connection_2][2] != 0:
            if sign(gears[connection_1][2]) == sign(gears[connection_2][2]):
                gears[gear_index_2][2] = 0
                break

    if gears[gear_index_2][2] != 0:
        formatted_velocity = f"{abs(round(gears[gear_index_2][2], 3)):.3f}"
        output_string = f"1\n{sign(gears[gear_index_2][2])}\n{formatted_velocity}"
    else:
        output_string = "-1"

    return output_string

print(process_input("Шестренки\input_s1_01.txt"))
