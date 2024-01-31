using Warudo.Core.Attributes;
using Warudo.Core.Graphs;

namespace FlameStream {
[NodeType(
    Id = "FlameStream.Node.GetGamepadReceiverDataNode",
    Title = "NODE_TITLE_GAMEPAD",
    Category = "NODE_CATEGORY"
)]
    public class GetGamepadReceiverDataNode : Node {

        [DataInput]
        public GamepadReceiverAsset Receiver;

        [DataOutput]
        [Label("NODE_IS_ACTIVE")]
        public bool IsActive() => Receiver != null && Receiver.Active;

        [DataOutput]
        [Label("NODE_IS_RECEIVING")]
        public bool IsReceiving() => Receiver != null && Receiver.IsReceiving;

        [DataOutput]
        [Label("NODE_A_BUTTON")]
        public bool A() => Receiver != null && Receiver.A;

        [DataOutput]
        [Label("NODE_B_BUTTON")]
        public bool B() => Receiver != null && Receiver.B;

        [DataOutput]
        [Label("NODE_X_BUTTON")]
        public bool X() => Receiver != null && Receiver.X;

        [DataOutput]
        [Label("NODE_Y_BUTTON")]
        public bool Y() => Receiver != null && Receiver.Y;

        [DataOutput]
        [Label("NODE_L_BUTTON")]
        public bool L() => Receiver != null && Receiver.L;

        [DataOutput]
        [Label("NODE_R_BUTTON")]
        public bool R() => Receiver != null && Receiver.R;

        [DataOutput]
        [Label("NODE_ZL_BUTTON")]
        public bool ZL() => Receiver != null && Receiver.ZL;

        [DataOutput]
        [Label("NODE_ZR_BUTTON")]
        public bool ZR() => Receiver != null && Receiver.ZR;

        [DataOutput]
        [Label("NODE_LEFT_STICK")]
        public bool LeftStick() => Receiver != null && Receiver.LeftStick;

        [DataOutput]
        [Label("NODE_RIGHT_STICK")]
        public bool RightStick() => Receiver != null && Receiver.RightStick;

        [DataOutput]
        [Label("NODE_HOME_BUTTON")]
        public bool Home() => Receiver != null && Receiver.Home;

        [DataOutput]
        [Label("NODE_CAPTURE_BUTTON")]
        public bool Capture() => Receiver != null && Receiver.Capture;

        [DataOutput]
        [Label("NODE_LEFT_STICK_X")]
        public float LeftStickX() => Receiver == null ? 0.5f : Receiver.LeftStickX;

        [DataOutput]
        [Label("NODE_LEFT_STICK_Y")]
        public float LeftStickY() => Receiver == null ? 0.5f : Receiver.LeftStickY;

        [DataOutput]
        [Label("NODE_RIGHT_STICK_X")]
        public float RightStickX() => Receiver == null ? 0.5f : Receiver.RightStickX;

        [DataOutput]
        [Label("NODE_RIGHT_STICK_Y")]
        public float RightStickY() => Receiver == null ? 0.5f : Receiver.RightStickY;

        [DataOutput]
        [Label("NODE_CONTROL_PAD")]
        public int ControlPad() => Receiver == null ? 5 : Receiver.ControlPad;
    }
}
