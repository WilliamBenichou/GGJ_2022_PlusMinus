using System.Collections;
using System.Collections.Generic;

public interface IPlayerComponent
{
    void Manage();
    void FixedManage();
    void InitModule();
    void Enable();
    void Disable();
    void Cleanup();
}