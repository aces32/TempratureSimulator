import time
from sensors.mock_sensor import read_sensor
from logger.log_writer import write_reading_to_csv

def is_anomaly(reading):
    # Simple range-based check
    return (
        reading["temperature"] < 21.0 or reading["temperature"] > 29.0
        or reading["humidity"] < 35.0 or reading["humidity"] > 55.0
    )

if __name__ == "__main__":
    for _ in range(10):
        reading = read_sensor()
        print("Reading:", reading)

        if is_anomaly(reading):
            from anomaly.llm_explainer import describe_anomaly
            explanation = describe_anomaly(reading)
            print("⚠️  Anomaly Detected!")
            print("🤖 AI Explanation:", explanation)

        write_reading_to_csv(reading)
        time.sleep(1)

