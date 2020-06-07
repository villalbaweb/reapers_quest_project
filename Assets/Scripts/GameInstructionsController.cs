using UnityEngine;

public class GameInstructionsController : MonoBehaviour
{
    // cache 
    Timer _timer;
    InstructionComponent[] _instructions;

    // Start is called before the first frame update
    void Start()
    {
        _timer = GetComponent<Timer>();

        _timer.OnFinished += ShowInstructions;
    }

    private void OnDestroy() {
        if(!_timer) return;

        _timer.OnFinished -= ShowInstructions;
    }

    void ShowInstructions()
    {
        _instructions = Resources.FindObjectsOfTypeAll<InstructionComponent>();

        foreach(InstructionComponent instruction in _instructions)
        {
            instruction.gameObject.SetActive(true);
        }
    }
}
