import json
from Process_Data import Process_Data

class Loader:
    def __init__(self):
        with open('./../kp.json', 'r') as kp:
            kp_data = json.load(kp)

        with open('./../sideness.json', 'r') as s:
            s_data = json.load(s)

        kp = Process_Data(kp_data)

        new_kp = kp.generate_data()

        new_json = json.dumps(new_kp)

        with open('./../output.json', 'w') as outfile:
            outfile.write(new_json)



Loader()
