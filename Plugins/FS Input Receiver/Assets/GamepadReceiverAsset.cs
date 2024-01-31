
using UnityEngine;
using Warudo.Core.Attributes;
using Warudo.Core.Scenes;

namespace FlameStream {
    [AssetType(
        Id = "FlameStream.Asset.GamepadReceiver",
        Title = "ASSET_TITLE_GAMEPAD"
    )]
    public class GamepadReceiverAsset : ReceiverAsset {

        const ushort PROTOCOL_VERSION = 1;
        const int DEFAULT_PORT = 40611;

        /// <summary>
        /// Using Nintendo Switch Notations
        /// </summary>
        public bool A;
        public bool B;
        public bool X;
        public bool Y;
        public bool L;
        public bool R;
        public bool ZL;
        public bool ZR;
        public bool Plus;
        public bool Minus;
        public bool LeftStick;
        public bool RightStick;
        public bool Home;
        public bool Capture;
        public float LeftStickX;
        public float LeftStickY;
        public float RightStickX;
        public float RightStickY;
        public byte ControlPad;

        protected override void OnCreate() {

            if (Port == 0) Port = DEFAULT_PORT;

            base.OnCreate();
        }

        public override void OnUpdate() {
            base.OnUpdate();

            if (lastState == null) return;

            var parts = lastState.Split(';');
            byte.TryParse(parts[0], out byte protocolVersion);
            if (protocolVersion != PROTOCOL_VERSION) {
                StopReceiver();
                SetMessage($"Invalid protocol '{protocolVersion}'. Expected '{PROTOCOL_VERSION}'");
                return;
            }

            B = parts[1] == "1";
            A = parts[2] == "1";
            Y = parts[3] == "1";
            X = parts[4] == "1";
            L = parts[5] == "1";
            R = parts[6] == "1";
            ZL = parts[7] == "1";
            ZR = parts[8] == "1";
            Plus = parts[9] == "1";
            Minus = parts[10] == "1";
            LeftStick = parts[11] == "1";
            RightStick = parts[12] == "1";
            Home = parts[13] == "1";
            Capture = parts[14] == "1";

            ushort.TryParse(parts[15], out ushort lsX);
            LeftStickX = lsX / (float)ushort.MaxValue;

            ushort.TryParse(parts[16], out ushort lsY);
            LeftStickY = lsY / (float)ushort.MaxValue;

            ushort.TryParse(parts[17], out ushort rsX);
            RightStickX = rsX / (float)ushort.MaxValue;

            ushort.TryParse(parts[18], out ushort rsY);
            RightStickY = rsY / (float)ushort.MaxValue;

            byte.TryParse(parts[19], out ControlPad);
        }

        protected override void Log(string msg) {
            Debug.Log($"[FlameStream.Asset.GamepadReceiver] {msg}");
        }
    }
}
