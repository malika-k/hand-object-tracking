import json

class Process_Data:

    def __init__(self,kp_data):
        self.kp_data = kp_data

    def generate_data(self):
        frames = []
        for (frame, data) in self.kp_data.items():
            if data: # if data is valid
                hand1 = data[0]
                hand2 = data[1]

                new_hand1 = self.process_hand(hand1)
                new_hand2 = self.process_hand(hand2)

                frame_obj = {
                    "hand1" : new_hand1,
                    "hand2" : new_hand2
                }
                frames.append(frame_obj)
            else:
                frames.append(None)

        return {
            "frames" : frames
        }

    def process_hand(self,hand_array):
        if hand_array:
            return self.process_joints(hand_array)
        else:
            return None


    def process_joints(self,joint_array):
        new_array = list(map(self.create_joint_dict, joint_array))
        counter = 0
        for obj in new_array:
            print(counter, obj["x"], obj["y"], obj["rel_depth"])
            counter += 1
        return new_array

    def create_joint_dict(self,joint):
        dict = {
            "x" : joint[0],
            "y" : joint[1],
            "rel_depth" : joint[2]
        }
        return dict
