import random
import datetime

def read_sensor():
    return {
        "timestamp": datetime.datetime.now().isoformat(),
        "temperature": round(random.uniform(20.0, 30.0), 2),
        "humidity": round(random.uniform(30.0, 60.0), 2)
    }
