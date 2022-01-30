using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerManager
{
    public const int PLAYER_COUNT = 2;

    private static bool s_isInitialized;
    private static GameControls[] s_playerActions;
    private static InputUser[] s_inputUsers;

    public static void InitIfNeeded()
    {
        if (!s_isInitialized)
        {
            Initialize();
        }
    }

    private static void Initialize()
    {
        s_playerActions = new GameControls[PLAYER_COUNT];
        s_inputUsers = new InputUser[PLAYER_COUNT];
        for (int i = 0; i < PLAYER_COUNT; i++)
        {
            s_playerActions[i] = new GameControls();
            s_playerActions[i].Enable();
            s_inputUsers[i] = InputUser.CreateUserWithoutPairedDevices();
            s_inputUsers[i].AssociateActionsWithUser(s_playerActions[i]);
            Bind_Internal(i, null);
        }

        s_inputUsers[0].ActivateControlScheme(s_playerActions[0].Player_1Scheme);
        s_inputUsers[1].ActivateControlScheme(s_playerActions[1].Player_2Scheme);
        
        s_isInitialized = true;
        
        
        //temporary todo: remove that
        Bind_Internal(0, Keyboard.current);
        Bind_Internal(1, Keyboard.current);
    }

    public static void Bind(int a_index, InputDevice a_device)
    {
        InitIfNeeded();
        Bind_Internal(a_index, a_device);
    }
    
    private static void Bind_Internal(int a_index, InputDevice a_device)
    {
        if (a_device == null)
        {
            s_inputUsers[a_index].UnpairDevices();
        }
        else
        {
            InputUser.PerformPairingWithDevice(a_device, s_inputUsers[a_index]);
        }
    }


    public static GameControls GetPlayerActions(int a_playerIndex)
    {
        InitIfNeeded();
        return s_playerActions[a_playerIndex];
    }

    public static InputDevice GetPlayerDevice(int a_playerIndex)
    {
        InitIfNeeded();
        return s_inputUsers[a_playerIndex].pairedDevices[0];
    }
}