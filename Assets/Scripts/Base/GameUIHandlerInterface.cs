
using System;

public interface GameUIHandlerInterface : GameHandler
{

	bool isSingle();
	bool isAllways();

	void Show();
	void UnShow();
}
