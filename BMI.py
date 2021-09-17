# a class to assign every person from the test data their properties.

class BMI:
    def _init_(self):
        self.fullname = ""  # as string
        self.height = 0.0  # as float
        self.weight = 0.0  # as float
        self.bmi = 0.0  # as float
        self.result = ""  # as string


def open_file(temp_array):
    with open("testdata.txt", "r") as temp_file:
        # opens th file testdata.txt as read only to read the data from it.

        row = 0

        # a variable to loop though each row and column in text file.

        for column in temp_file:
            line_split = column.split(",")

            # sets the rows to be spilt at each comma "," in the text file.

            temp_array[row].fullname = str(line_split[0])
            temp_array[row].height = float(line_split[1])
            temp_array[row].weight = float(line_split[2])

            # sets each property of the array to the data from the text file for the current column.

            row += 1

            # moves to the next row.

    temp_file.close()

    # closes the file.


def result(temp_list):
    for counter in range(len(temp_list)):

        # loops for the length of the list

        if temp_list[counter].bmi < 18.5:
            temp_list[counter].result = "underweight"

        elif 18.5 <= temp_list[counter].bmi < 25:
            temp_list[counter].result = "an ideal weight"

        else:
            temp_list[counter].result = "overweight"

        # sets the property of temp_list.result for each record in the array, depending on the temp_list.bmi of said
        # record.


def write_file(temp_list):
    with open("bmi_results.txt", "w") as temp_file:
        for counter in range(len(temp_list)):
            temp_record = "{}'s height is {} m and their weight is {}kgs and their BMI is {}. " \
                          "Overall they are {}."

            # creates a record to be written

            temp_record = temp_record.format(temp_list[counter].fullname, temp_list[counter].height,
                                             temp_list[counter].weight, temp_list[counter].bmi,
                                             temp_list[counter].result)

            # formats the record in the next line for better clarity.

            temp_file.write(temp_record)
            temp_file.write("\n")

            # writes the record to the text file "bmi_results.txt".

    temp_file.close()


def set_bmi(temp_list):
    for person in range(len(temp_list)):
        height_squared = temp_list[person].height ** 2
        temp_list[person].bmi = temp_list[person].weight / height_squared
        temp_list[person].bmi = round(temp_list[person].bmi, 1)

        # calculates each persons BMI from their height and weight using the equation b = w / h^2. Then this is
        # rounded to 1 decimal places, done in multiple lines for better clarity.


bmi_array = [BMI() for counter in range(5)]

# creates an array with the BMI() class with a length of five

open_file(bmi_array)
set_bmi(bmi_array)
result(bmi_array)
write_file(bmi_array)
