using Invector.CharacterController;

public class JetPack : Gadget {

    public override void EnableGadget()
    {
        base.EnableGadget();
        vThirdPersonController.instance.MultiJump = 2;
    }

}
