import csv
import os

def write_reading_to_csv(reading, path="data/sensor_readings.csv"):
    os.makedirs(os.path.dirname(path), exist_ok=True)
    file_exists = os.path.isfile(path)

    with open(path, "a", newline="") as csvfile:
        fieldnames = ["timestamp", "temperature", "humidity"]
        writer = csv.DictWriter(csvfile, fieldnames=fieldnames)

        if not file_exists:
            writer.writeheader()

        writer.writerow(reading)
