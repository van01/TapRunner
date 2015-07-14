using UnityEngine;
using System.Collections;

public interface PopupListener{

	void onClose();
	void onCancel();
	void onOK();
}
