import requests

def describe_anomaly(readings):
    lines = [
        "You are a data analyst for ATS Life Sciences Europe.",
        "Respond clearly and concisely when analyzing data.",
        "Analyze the following temperature readings and highlight trends or anomalies:",
        "",
        "timestamp,Temperature,humidity"
    ]

    if isinstance(readings, list):
        for row in readings:
            if isinstance(row, dict):
                lines.append(f"{row['humidity']},{row['temperature']},{row['timestamp']}")
            else:
                lines.append(str(row))
    else:
        lines.append(str(readings))

    prompt = "\n".join(lines)

    try:
        response = requests.post(
            "http://localhost:11434/api/generate",
            json={"model": "llama3", "prompt": prompt, "stream": False}
        )
        data = response.json()
        return data.get("response", "No explanation received.")
    except Exception as e:
        return f"Error calling LLM: {e}"

