using System.Collections.Generic;
using UnityEngine;


public class ConsoleAdd : MonoBehaviour
{
	struct Log
	{
		public string message;
		public string stackTrace;
		public LogType type;
	}


	public KeyCode toggleKey = KeyCode.E;

	List<Log> logs = new List<Log>();
	Vector2 scrollPosition;
	bool show;

	static readonly Dictionary<LogType, Color> logTypeColors = new Dictionary<LogType, Color>()
	{
		{ LogType.Assert, Color.white },
		{ LogType.Error, Color.red },
		{ LogType.Exception, Color.red },
		{ LogType.Log, Color.white },
		{ LogType.Warning, Color.yellow },
	};

	const int margin = 100;

	Rect windowRect = new Rect(margin, Screen.height-(margin+10), Screen.width - (margin * 2), Screen.height - (margin * 5));

	void OnEnable ()
	{
		Application.RegisterLogCallback(HandleLog);
	}

	void OnDisable ()
	{
		Application.RegisterLogCallback(null);
	}

	void Update ()
	{
		if (Input.GetKeyDown(toggleKey)) {
			show = !show;
		}

	}

	void OnGUI ()
	{
		if (!show) {
			return;
		}

		windowRect = GUILayout.Window(123456, windowRect, ConsoleWindow, "Console");
	}

	void ConsoleWindow (int windowID)
	{
		scrollPosition = GUILayout.BeginScrollView(scrollPosition);

			// Iterate through the recorded logs.
			for (int i = 0; i < logs.Count; i++) {
				var log = logs[i];

				GUI.contentColor = logTypeColors[log.type];
				GUILayout.Label(log.message);
			}

		GUILayout.EndScrollView();
		GUI.contentColor = Color.white;
		GUILayout.BeginHorizontal();
		GUILayout.EndHorizontal();

	}

	/// Records a log from the log callback.
	void HandleLog (string message, string stackTrace, LogType type)
	{
		logs.Add(new Log() {
			message = message,
			stackTrace = stackTrace,
			type = type,
		});

	}
}
