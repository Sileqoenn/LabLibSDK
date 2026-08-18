#if UNITY_EDITOR
using NoodledEvents;
using SLZ.Bonelab;
using SLZ.Marrow.Warehouse;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using UltEvents;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.State;
using static NoodledEvents.CookBook.NodeDef;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using UObject = UnityEngine.Object;

public class LabLibCookBook : CookBook
{
    public override void CollectDefs(Action<IEnumerable<NodeDef>, float> progressCallback, Action completedCallback)
    {
        List<NodeDef> allDefs = new();

        allDefs.Add(new NodeDef(this, "lablib.registerMod",
             inputs: () => new[] { new Pin("Exec"), new Pin("pallet", typeof(Pallet), true) },
            outputs: () => new[] { new Pin("Done") },
            bookTag: "registerMod"));
        allDefs.Add(new NodeDef(this, "lablib.isModRegistered",
             inputs: () => new[] { new Pin("Exec"), new Pin("pallet", typeof(Pallet), true) },
            outputs: () => new[] { new Pin("Done"), new Pin("registered", typeof(bool), true) },
            bookTag: "isModRegistered"));
        allDefs.Add(new NodeDef(this, "lablib.addChangeCallback",
             inputs: () => new[] { new Pin("Exec"), new Pin("pallet", typeof(Pallet), true) , new Pin("callback object", typeof(UObject), true), new Pin("var name", typeof(string), true) },
            outputs: () => new[] { new Pin("Done") },
            bookTag: "addChangeCallback"));
        allDefs.Add(new NodeDef(this, "lablib.notify",
             inputs: () => new[] { new Pin("Exec"), new Pin("title", typeof(string)), new Pin("subtitle", typeof(string)), new Pin("type", typeof(int)), new Pin("hold", typeof(float)) },
            outputs: () => new[] { new Pin("Done") },
            bookTag: "notify"));
        allDefs.Add(new NodeDef(this, "lablib.makeUiSpacing",
             inputs: () => new[] { new Pin("Exec"), new Pin("pallet", typeof(Pallet), true) },
            outputs: () => new[] { new Pin("Done") },
            bookTag: "makeUiSpacing"));
        allDefs.Add(new NodeDef(this, "lablib.makeUiTitle",
             inputs: () => new[] { new Pin("Exec"), new Pin("pallet", typeof(Pallet), true), new Pin("text", typeof(string), true), new Pin("color", typeof(Color), true) },
            outputs: () => new[] { new Pin("Done") },
            bookTag: "makeUiTitle"));
        allDefs.Add(new NodeDef(this, "lablib.makeBool",
             inputs: () => new[] { new Pin("Exec"), new Pin("pallet", typeof(Pallet), true), new Pin("name", typeof(string), true), new Pin("default value", typeof(bool), true), new Pin("color", typeof(Color), true) },
            outputs: () => new[] { new Pin("Done") },
            bookTag: "makeBool"));
        allDefs.Add(new NodeDef(this, "lablib.makeInt",
             inputs: () => new[] { new Pin("Exec"), new Pin("pallet", typeof(Pallet), true), new Pin("name", typeof(string), true), new Pin("default value", typeof(int), true), new Pin("increment", typeof(int), true), new Pin("min", typeof(int), true), new Pin("max", typeof(int), true), new Pin("color", typeof(Color), true) },
            outputs: () => new[] { new Pin("Done") },
            bookTag: "makeInt"));
        allDefs.Add(new NodeDef(this, "lablib.makeFloat",
             inputs: () => new[] { new Pin("Exec"), new Pin("pallet", typeof(Pallet), true), new Pin("name", typeof(string), true), new Pin("default value", typeof(float), true), new Pin("increment", typeof(float), true), new Pin("min", typeof(float), true), new Pin("max", typeof(float), true), new Pin("color", typeof(Color), true) },
            outputs: () => new[] { new Pin("Done") },
            bookTag: "makeFloat"));
        allDefs.Add(new NodeDef(this, "lablib.makeEnum",
             inputs: () => new[] { new Pin("Exec"), new Pin("pallet", typeof(Pallet), true), new Pin("name", typeof(string), true), new Pin("default value", typeof(int), true), new Pin("enum value array", typeof(string), true), new Pin("color", typeof(Color), true) },
            outputs: () => new[] { new Pin("Done") },
            bookTag: "makeEnum"));
        allDefs.Add(new NodeDef(this, "lablib.makeEvent",
             inputs: () => new[] { new Pin("Exec"), new Pin("pallet", typeof(Pallet), true), new Pin("name", typeof(string), true), new Pin("color", typeof(Color), true) },
            outputs: () => new[] { new Pin("Done") },
            bookTag: "makeEvent"));
        allDefs.Add(new NodeDef(this, "lablib.isSpawnedWithLabLib",
             inputs: () => new[] { new Pin("Exec") },
            outputs: () => new[] { new Pin("Done"), new Pin("spawned with lablib", typeof(bool), true) },
            bookTag: "isSpawnedWithLabLib"));
        allDefs.Add(new NodeDef(this, "lablib.harmony.patchPrefix",
             inputs: () => new[] { new Pin("Exec"), new Pin("class", typeof(Type)), new Pin("methodName", typeof(string)), new Pin("params", typeof(string)) },
            outputs: () => new[] { new Pin("On Patch"), new Pin("On Triggered"), new Pin("__instance", typeof(object), true), new Pin("params", typeof(object[]), true) },
            bookTag: "harmonyPatchPrefix"));
        allDefs.Add(new NodeDef(this, "lablib.harmony.patchPostfix",
             inputs: () => new[] { new Pin("Exec"), new Pin("class", typeof(Type)), new Pin("methodName", typeof(string)), new Pin("params", typeof(string)) },
            outputs: () => new[] { new Pin("On Patch"), new Pin("On Triggered"), new Pin("__instance", typeof(object), true), new Pin("params", typeof(object[]), true) },
            bookTag: "harmonyPatchPostfix"));
        allDefs.Add(new NodeDef(this, "lablib.harmony.invokeOriginal",
             inputs: () => new[] { new Pin("Exec"), new Pin("invoke original", typeof(bool)) },
            outputs: () => new[] { new Pin("Done") },
            bookTag: "harmonyInvokeOriginal"));
        allDefs.Add(new NodeDef(this, "op.not",
             inputs: () => new[] { new Pin("Exec"), new Pin("a", typeof(bool)) },
            outputs: () => new[] { new Pin("Done"), new Pin("!a", typeof(bool)) },
            bookTag: "opnot"));
        allDefs.Add(new NodeDef(this, "op.or",
             inputs: () => new[] { new Pin("Exec"), new Pin("a", typeof(bool)), new Pin("b", typeof(bool)) },
            outputs: () => new[] { new Pin("Done"), new Pin("a | b", typeof(bool)) },
            bookTag: "opor"));
        allDefs.Add(new NodeDef(this, "op.and",
             inputs: () => new[] { new Pin("Exec"), new Pin("a", typeof(bool)), new Pin("b", typeof(bool)) },
            outputs: () => new[] { new Pin("Done"), new Pin("a & b", typeof(bool)) },
            bookTag: "opand"));
        allDefs.Add(new NodeDef(this, "op.xor",
             inputs: () => new[] { new Pin("Exec"), new Pin("a", typeof(bool)), new Pin("b", typeof(bool)) },
            outputs: () => new[] { new Pin("Done"), new Pin("a ^ b", typeof(bool)) },
            bookTag: "opxor"));
        allDefs.Add(new NodeDef(this, "op.isNull",
             inputs: () => new[] { new Pin("Exec"), new Pin("a", typeof(object)) },
            outputs: () => new[] { new Pin("Done"), new Pin("a == null", typeof(bool)) },
            bookTag: "opisnull"));

        progressCallback.Invoke(allDefs, 1);
        completedCallback.Invoke();
    }
    private static Transform compgetter;
    private static Transform prevdataroot;
    public override void CompileNode(UltEventBase evt, SerializedNode node, Transform dataRoot)
    {
        base.CompileNode(evt, node, dataRoot);
        if (evt.PersistentCallsList == null) evt.FSetPCalls(new());

        /*
         * The code is shit and inconsistent because im soo tired
         * and i dont want to redo everything again to make things make sense, so bear with the inconsistencies and lack of comments!
         */

        var tp = typeof(Type);
        var tr = typeof(Transform);
        var go = typeof(GameObject);
        var cm = typeof(Component);
        var m_gettype = tp.GetMethods().First(m => m.Name == "GetType" && m.GetParameters().Length == 3);
        var m_getcomp = cm.GetMethod("GetComponentInParent", UltEventUtils.AnyAccessBindings, null, new Type[] { typeof(Type), typeof(bool) }, null);
        var m_invokeholder = typeof(UltEventHolder).GetMethods().First(m => m.Name == "Invoke" && m.DeclaringType == typeof(UltEventHolder));
        var m_setsource = typeof(XRInteractorAffordanceStateProvider).GetMethod("set_interactorSource", UltEventUtils.AnyAccessBindings | BindingFlags.SetProperty);
        var m_settext = typeof(Text).GetMethods().First(m => m.Name == "set_text");
        var m_setshowmask = typeof(Mask).GetMethods().First(m => m.Name == "set_showMaskGraphic");
        var m_setcolor = typeof(SpriteRenderer).GetMethods().First(m => m.Name == "set_color");
        if ((node.BookTag != "isSpawnedWithLabLib" && !node.BookTag.Contains("harmony") && !node.BookTag.Contains("op")) && (compgetter == null || prevdataroot != dataRoot))
            compgetter = dataRoot.StoreTransform("compgetter");
        var tr_find = tr.GetMethod("Find");
        const string APIPATH = "/GameplaySystems [0]/LabLib/API/";

        MethodInfo FindGetSet(Type type, string name) =>
            type.GetMethods().First(m => m.Name == name);

        int GetComponentInParent(Component target, Type type)
        {
            int gettypeidx = evt.PersistentCallsList.FindOrAddGetTyper(type);

            var call_getcomp = new PersistentCall(m_getcomp, target);
            call_getcomp.PersistentArguments[0].ToRetVal(gettypeidx, tp);
            call_getcomp.PersistentArguments[1].Bool = true;
            evt.PersistentCallsList.Add(call_getcomp);

            return evt.PersistentCallsList.Count - 1;
        }
        int ParentToTransform(string path)
        {
            var call_arg0 = new PersistentCall(tr_find, compgetter);
            call_arg0.PersistentArguments[0].String = path;
            evt.PersistentCallsList.Add(call_arg0);
            int arg0idx = evt.PersistentCallsList.Count - 1;

            var call_parent = new PersistentCall(tr.GetMethod("SetParent", UltEventUtils.AnyAccessBindings, null, new Type[] { typeof(Transform) }, null), compgetter);
            call_parent.PersistentArguments[0].ToRetVal(arg0idx, tr);
            evt.PersistentCallsList.Add(call_parent);

            return evt.PersistentCallsList.Count - 1;
        }
        int Log()
        {
            var call_parent = new PersistentCall(typeof(Debug).GetMethod("Log", UltEventUtils.AnyAccessBindings, null, new Type[] { typeof(object) }, null), null);
            call_parent.PersistentArguments[0].ToRetVal(evt.PersistentCallsList.Count - 1, tr);
            evt.PersistentCallsList.Add(call_parent);
            return evt.PersistentCallsList.Count - 1; 
        }
        int TransformClimb()
        {
            var arg0 = new PersistentCall(tr.GetMethod("Find", UltEventUtils.AnyAccessBindings, null, new Type[] { typeof(string) }, null), compgetter);
            arg0.PersistentArguments[0].FSetString("../../");
            int arg0idx = evt.PersistentCallsList.Count;
            evt.PersistentCallsList.Add(arg0);

            var call_parent = new PersistentCall(tr.GetMethod("SetParent", UltEventUtils.AnyAccessBindings, null, new Type[] { typeof(Transform) }, null), compgetter);
            call_parent.PersistentArguments[0].ToRetVal(arg0idx, tr);
            evt.PersistentCallsList.Add(call_parent);

            return evt.PersistentCallsList.Count - 1;
        }
        int GameobjectFind(string path)
        {
            var call = new PersistentCall(go.GetMethod("Find"), null);
            call.PersistentArguments[0].String = path;
            evt.PersistentCallsList.Add(call);

            return evt.PersistentCallsList.Count - 1;
        }
        int ObjectSetname(int index, NoodleDataInput source)
        {
            var call = new PersistentCall(null, null);
            call.FSetMethodName(typeof(UObject).AssemblyQualifiedName + ".SetName");
            call.FSetArguments(
                new PersistentArgument().ToRetVal(index, typeof(UObject)),
                new PersistentArgument().FSetType(PersistentArgumentType.String));

            if (source.Source != null)
            {
                new PendingConnection(source.Source, evt, call, 1).Connect(dataRoot);
                evt.PersistentCallsList.Add(call);
            }
            else
            {
                evt.PersistentCallsList.Add(call);
                var arg = call.PersistentArguments[1];

                arg.String = source.DefaultStringValue;
            }


            return evt.PersistentCallsList.Count - 1;
        }
        // pending connection support
        int AddRunMethod(MethodInfo method, int objIdx, object[] param, params NoodleDataInput[] inputs)
        {
            int m = evt.PersistentCallsList.FindOrAddGetMethodInfo(method);

            param ??= new object[0];
            int paramArr = evt.PersistentCallsList.CreateArray(typeof(object), param.Length, @new: true);
            // setup paramz
            for (int i = 0; i < param.Length; i++)
            {
                var curParam = param[i];
                Debug.Log(inputs != null);
                Debug.Log(inputs.Length < i);
                Debug.Log(inputs[i].Source != null);
                if (curParam == null)
                    continue;
                else if (inputs != null && i < inputs.Length && inputs[i].Source != null)
                {
                    var editorSetCall = new PersistentCall(typeof(UltNoodleRuntimeExtensions).GetMethod("ArrayItemSetter1", UltEventUtils.AnyAccessBindings), null);
                    editorSetCall.PersistentArguments[0].ToRetVal(paramArr, typeof(Array));
                    editorSetCall.PersistentArguments[1].Int = i;
                    editorSetCall.PersistentArguments[2].ToRetVal(0, typeof(object));

                    new PendingConnection(inputs[i].Source, evt, editorSetCall, 2).Connect(dataRoot);

                    evt.PersistentCallsList.Add(editorSetCall);

                    continue;
                }
                else if (curParam is int retVal)
                    evt.PersistentCallsList.AddArraySet(paramArr, retVal, i);
                else if (curParam is PersistentArgument pa)
                {
                    // const usually.
                    evt.PersistentCallsList.AddArraySet(paramArr, pa, i);
                }
            }

            var invokeCall = new PersistentCall(Type.GetType("System.SecurityUtils, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", true, true).GetMethod("MethodInfoInvoke", UltEventUtils.AnyAccessBindings, null, new Type[] { typeof(MethodInfo), typeof(object), typeof(object[]) }, null), null);
            invokeCall.PersistentArguments[0].ToRetVal(m, typeof(MethodInfo));
            if (objIdx < 0)
                invokeCall.PersistentArguments[1].FSetString(typeof(object).AssemblyQualifiedName)
                    .FSetType(PersistentArgumentType.Object).FSetInt(0);
            else
                invokeCall.PersistentArguments[1].ToRetVal(objIdx, typeof(object));
            invokeCall.PersistentArguments[2].ToRetVal(paramArr, typeof(object[]));
            evt.PersistentCallsList.Add(invokeCall);
            return evt.PersistentCallsList.Count - 1;
        }

        MethodInfo objequals = typeof(object).GetMethod("Equals", UltEventUtils.AnyAccessBindings, null, new Type[] { typeof(object), typeof(object) }, null);
        void objeqArgHelper(PersistentCall call, int argidx, int idx, NoodleDataInput input, Type overrid = null)
        {
            call.PersistentArguments[argidx].FSetType(PersistentArgumentType.Bool);
            if (input != null)
            {
                if (input.Source == null)
                    call.PersistentArguments[argidx].FSetInt(input.DefaultBoolValue ? 1 : 0);
                else
                    new PendingConnection(input.Source, evt, call, argidx).Connect(dataRoot);
            }
            else
                call.PersistentArguments[argidx].ToRetVal(idx, overrid is not null ? overrid : typeof(bool));
        }
        int AddIsNull(int param, NoodleDataInput input)
        {
            var call = new PersistentCall(objequals, null);
            call.PersistentArguments[1].FSetType(PersistentArgumentType.Object);
            call.PersistentArguments[0].FSetType(PersistentArgumentType.Object);
            if (input != null)
            {
                if (input.Source == null)
                    call.PersistentArguments[0].FSetObject(input.DefaultObject);
                else
                    new PendingConnection(input.Source, evt, call, 0).Connect(dataRoot);
            }
            else
                call.PersistentArguments[0].ToRetVal(param, typeof(object));

            evt.PersistentCallsList.Add(call);
            return evt.PersistentCallsList.Count - 1;
        }
        int AddNot(int param, NoodleDataInput input)
        {
            var call = new PersistentCall(objequals, null);
            call.PersistentArguments[1].FSetType(PersistentArgumentType.Bool).FSetInt(0);
            objeqArgHelper(call, 0, param, input);

            evt.PersistentCallsList.Add(call);
            return evt.PersistentCallsList.Count - 1;
        }
        int sqlboolAnd(int a, int b, NoodleDataInput ia, NoodleDataInput ib)
        {
            var call = new PersistentCall(typeof(SqlBoolean).GetMethod("op_BitwiseAnd"), null);
            objeqArgHelper(call, 0, a, ia, typeof(SqlBoolean));
            objeqArgHelper(call, 1, b, ib, typeof(SqlBoolean));

            evt.PersistentCallsList.Add(call);
            return evt.PersistentCallsList.Count - 1;
        }
        int sqlboolImplcit(int param, NoodleDataInput input)
        {
            var call = new PersistentCall(typeof(SqlBoolean).GetMethod("op_Implicit"), null);
            objeqArgHelper(call, 0, param, input, typeof(bool));

            evt.PersistentCallsList.Add(call);
            return evt.PersistentCallsList.Count - 1;
        }
        int AddAnd(int a, int b, NoodleDataInput ia, NoodleDataInput ib)
        {
            int sqla = sqlboolImplcit(a, ia);
            int sqlb = sqlboolImplcit(b, ib);

            int sqlXor = sqlboolAnd(sqla, sqlb, null, null);
            return sqlboolTrue(sqlXor, null);
        }
        int sqlboolOr(int a, int b, NoodleDataInput ia, NoodleDataInput ib)
        {
            var call = new PersistentCall(typeof(SqlBoolean).GetMethod("op_BitwiseOr"), null);
            objeqArgHelper(call, 0, a, ia, typeof(SqlBoolean));
            objeqArgHelper(call, 1, b, ib, typeof(SqlBoolean));

            evt.PersistentCallsList.Add(call);
            return evt.PersistentCallsList.Count - 1;
        }
        int sqlboolTrue(int param, NoodleDataInput input)
        {
            var call = new PersistentCall(typeof(SqlBoolean).GetMethod("op_True"), null);
            objeqArgHelper(call, 0, param, input, typeof(SqlBoolean));

            evt.PersistentCallsList.Add(call);
            return evt.PersistentCallsList.Count - 1;
        }
        int AddOr(int a, int b, NoodleDataInput ia, NoodleDataInput ib)
        {
            int sqla = sqlboolImplcit(a, ia);
            int sqlb = sqlboolImplcit(b, ib);

            int sqlXor = sqlboolOr(sqla, sqlb, null, null);
            return sqlboolTrue(sqlXor, null);
        }
        int AddXor(int a, int b, NoodleDataInput ia, NoodleDataInput ib)
        {
            // A ^ B = (A & !B) | (!A & B)
            int nB = AddNot(b, ib);
            int AanB = AddAnd(a, nB, ia, null);

            int nA = AddNot(a, ia);
            int BanA = AddAnd(b, nA, ib, null);

            return AddOr(AanB, BanA, null, null);
        }

        void harmonyPatch(bool post)
        {
            string type = post ? "Postfix" : "Prefix";
            var evtPatch = dataRoot.StoreComp<UltEventHolder>($"{node.DataInputs[0].DefaultStringValue}/{node.DataInputs[1].DefaultStringValue}/[{node.DataInputs[2].DefaultStringValue}]/@{type}");
            evtPatch.Event.FSetPCalls(new());
            evtPatch.gameObject.SetActive(true);
            var trampoline = evtPatch.gameObject.AddComponent(Type.GetType("SLZ.Bonelab.BlipHelper, Assembly-CSharp", true, true));
            var pass = evtPatch.gameObject.AddComponent<Mask>();

            node.DataOutputs[0].CompEvt = evtPatch.Event;
            node.DataOutputs[0].CompAsParam = 0;
            node.DataOutputs[0].UseCompAsParam = true;

            node.DataOutputs[1].CompEvt = evtPatch.Event;
            node.DataOutputs[1].CompAsParam = 1;
            node.DataOutputs[1].UseCompAsParam = true;

            var preNext = node.FlowOutputs[1].Target?.Node;
            if (preNext != null)
                preNext.Book.CompileNode(evtPatch.Event, preNext, evtPatch.transform);

            evt.PersistentCallsList.Add(new PersistentCall(Type.GetType("SLZ.Bonelab.BlipHelper, Assembly-CSharp", true, true).GetMethod("DESTROYOBJ"), trampoline));

            var evtNext = node.FlowOutputs[0].Target?.Node;
            if (evtNext != null)
                evtNext.Book.CompileNode(evt, evtNext, dataRoot);
        }
        switch (node.BookTag)
        {
            case "registerMod":
                {
                    ParentToTransform(APIPATH + "RegisterMod/pallet");

                    int pallet = GetComponentInParent(compgetter, typeof(XRInteractorAffordanceStateProvider));
                    evt.PersistentCallsList.AddRunMethod(m_setsource, pallet, 
                        new PersistentArgument()
                            .FSetType(PersistentArgumentType.Object)
                            .FSetString(typeof(Pallet).AssemblyQualifiedName)
                            .FSetObject(node.DataInputs[0].DefaultObject));

                    int ultevent = GetComponentInParent(compgetter, typeof(UltEventHolder));

                    evt.PersistentCallsList.AddRunMethod(m_invokeholder, ultevent);

                    var evtNext3 = node.FlowOutputs[0].Target?.Node;
                    if (evtNext3 != null)
                        evtNext3.Book.CompileNode(evt, evtNext3, dataRoot);
                } break;
            case "isModRegistered":
                {
                    ParentToTransform(APIPATH + "IsModRegistered/pallet/retval");

                    int pallet = GetComponentInParent(compgetter, typeof(XRInteractorAffordanceStateProvider));
                    evt.PersistentCallsList.AddRunMethod(m_setsource, pallet, 
                        new PersistentArgument()
                            .FSetType(PersistentArgumentType.Object)
                            .FSetString(typeof(Pallet).AssemblyQualifiedName)
                            .FSetObject(node.DataInputs[0].DefaultObject));

                    int ultevent = GetComponentInParent(compgetter, typeof(UltEventHolder));
                    evt.PersistentCallsList.AddRunMethod(m_invokeholder, ultevent);

                    int sretval = GetComponentInParent(compgetter, typeof(Mask));
                    int retval = evt.PersistentCallsList.AddRunMethod(FindGetSet(typeof(Mask), "get_showMaskGraphic"), sretval);

                    var negate = new PersistentCall(null, null);
                    negate.FSetMethodName("System.Object, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089.Equals");
                    negate.FSetArguments(
                        new PersistentArgument().ToRetVal(retval, typeof(bool)),
                        new PersistentArgument().FSetType(PersistentArgumentType.Bool));
                    evt.PersistentCallsList.Add(negate);

                    node.DataOutputs[0].CompEvt = evt;
                    node.DataOutputs[0].CompCall = evt.PersistentCallsList[^1];

                    var evtNext3 = node.FlowOutputs[0].Target?.Node;
                    if (evtNext3 != null)
                        evtNext3.Book.CompileNode(evt, evtNext3, dataRoot);
                } break;
            case "isSpawnedWithLabLib":
                {

                    var path = new PersistentCall(null, null);
                    path.FSetMethodName("SLZ.Marrow.Utilities.ObjectPathExtensions, SLZ.Marrow, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null.ObjectPath");
                    path.FSetArguments(
                        new PersistentArgument().FSetType(PersistentArgumentType.Object).FSetObject(dataRoot).FSetString(tr.AssemblyQualifiedName)
                    );
                    evt.PersistentCallsList.Add(path);

                    var ismatch = new PersistentCall(null, null);
                    ismatch.FSetMethodName("System.Text.RegularExpressions.Regex, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089.IsMatch");
                    ismatch.FSetArguments(
                        new PersistentArgument().ToRetVal(evt.PersistentCallsList.Count - 1, typeof(string)),
                        new PersistentArgument().FSetType(PersistentArgumentType.String).FSetString(@"^.+\/LabLib\/SpawnMods\/SpawnedMods")
                        );
                    evt.PersistentCallsList.Add(ismatch);

                    node.DataOutputs[0].CompEvt = evt;
                    node.DataOutputs[0].CompCall = evt.PersistentCallsList[^1];

                    var evtNext3 = node.FlowOutputs[0].Target?.Node;
                    if (evtNext3 != null)
                        evtNext3.Book.CompileNode(evt, evtNext3, dataRoot);
                } break;
            case "addChangeCallback":
                {
                    ParentToTransform(APIPATH + "AddChangeCallback/pallet/name/callback");

                    int callback = GetComponentInParent(compgetter, typeof(XRInteractorAffordanceStateProvider));
                    evt.PersistentCallsList.AddRunMethod(m_setsource, callback,
                        new PersistentArgument()
                            .FSetType(PersistentArgumentType.Object)
                            .FSetString(typeof(UObject).AssemblyQualifiedName)
                            .FSetObject(node.DataInputs[1].DefaultObject));

                    TransformClimb();

                    int pallet = GetComponentInParent(compgetter, typeof(XRInteractorAffordanceStateProvider));
                    evt.PersistentCallsList.AddRunMethod(m_setsource, pallet,
                        new PersistentArgument()
                            .FSetType(PersistentArgumentType.Object)
                            .FSetString(typeof(Pallet).AssemblyQualifiedName)
                            .FSetObject(node.DataInputs[0].DefaultObject));

                    ObjectSetname(GameobjectFind(APIPATH + "AddChangeCallback/pallet/name"), node.DataInputs[2]);

                    int ultevent = GetComponentInParent(compgetter, typeof(UltEventHolder));

                    evt.PersistentCallsList.AddRunMethod(m_invokeholder, ultevent);

                    var evtNext3 = node.FlowOutputs[0].Target?.Node;
                    if (evtNext3 != null)
                        evtNext3.Book.CompileNode(evt, evtNext3, dataRoot);
                } break;
            case "makeBool":
                {
                    ParentToTransform(APIPATH + "MakeBool/args");

                    int pallet = GetComponentInParent(compgetter, typeof(XRInteractorAffordanceStateProvider));
                    evt.PersistentCallsList.AddRunMethod(m_setsource, pallet,
                        new PersistentArgument()
                            .FSetType(PersistentArgumentType.Object)
                            .FSetString(typeof(UObject).AssemblyQualifiedName)
                            .FSetObject(node.DataInputs[0].DefaultObject));

                    int name = GetComponentInParent(compgetter, typeof(Text));
                    evt.PersistentCallsList.AddRunMethod(m_settext, name,
                        new PersistentArgument()
                            .FSetType(PersistentArgumentType.String)
                            .FSetString(node.DataInputs[1].DefaultStringValue));

                    int defaultvalue = GetComponentInParent(compgetter, typeof(Mask));
                    var argdv = new PersistentArgument().FSetType(PersistentArgumentType.Bool);
                    argdv.Bool = node.DataInputs[2].DefaultBoolValue;
                    evt.PersistentCallsList.AddRunMethod(m_setshowmask, defaultvalue, argdv);

                    int color = GetComponentInParent(compgetter, typeof(SpriteRenderer));
                    var argc = new PersistentArgument().FSetType(PersistentArgumentType.Color);
                    argc.Color = node.DataInputs[3].DefaultColorValue;
                    evt.PersistentCallsList.AddRunMethod(m_setcolor, color, argc);

                    int invokeridx = GetComponentInParent(compgetter, typeof(UltEventHolder));

                    evt.PersistentCallsList.AddRunMethod(m_invokeholder, invokeridx);

                    var evtNext3 = node.FlowOutputs[0].Target?.Node;
                    if (evtNext3 != null)
                        evtNext3.Book.CompileNode(evt, evtNext3, dataRoot);
                } break;
            case "makeInt":
                {
                    ParentToTransform(APIPATH + "MakeInt/args");

                    int pallet = GetComponentInParent(compgetter, typeof(XRInteractorAffordanceStateProvider));
                    evt.PersistentCallsList.AddRunMethod(m_setsource, pallet,
                        new PersistentArgument()
                            .FSetType(PersistentArgumentType.Object)
                            .FSetString(typeof(UObject).AssemblyQualifiedName)
                            .FSetObject(node.DataInputs[0].DefaultObject));

                    int name = GetComponentInParent(compgetter, typeof(Text));
                    evt.PersistentCallsList.AddRunMethod(m_settext, name,
                        new PersistentArgument()
                            .FSetType(PersistentArgumentType.String)
                            .FSetString(node.DataInputs[1].DefaultStringValue));

                    int DefIncMinMaxColor = GetComponentInParent(compgetter, typeof(LineRenderer));
                    var def = new PersistentArgument().FSetType(PersistentArgumentType.Int);
                    def.Int = node.DataInputs[2].DefaultIntValue;
                    evt.PersistentCallsList.AddRunMethod(FindGetSet(typeof(LineRenderer), "set_positionCount"), DefIncMinMaxColor, def);

                    var inc = new PersistentArgument().FSetType(PersistentArgumentType.Int);
                    inc.Int = node.DataInputs[3].DefaultIntValue;
                    evt.PersistentCallsList.AddRunMethod(FindGetSet(typeof(LineRenderer), "set_numPositions"), DefIncMinMaxColor, inc);

                    var min = new PersistentArgument().FSetType(PersistentArgumentType.Int);
                    min.Int = node.DataInputs[4].DefaultIntValue;
                    evt.PersistentCallsList.AddRunMethod(FindGetSet(typeof(LineRenderer), "set_numCornerVertices"), DefIncMinMaxColor, min);

                    var max = new PersistentArgument().FSetType(PersistentArgumentType.Int);
                    max.Int = node.DataInputs[5].DefaultIntValue;
                    evt.PersistentCallsList.AddRunMethod(FindGetSet(typeof(LineRenderer), "set_numCapVertices"), DefIncMinMaxColor, max);

                    var color = new PersistentArgument().FSetType(PersistentArgumentType.Color);
                    color.Color = node.DataInputs[6].DefaultColorValue;
                    evt.PersistentCallsList.AddRunMethod(FindGetSet(typeof(LineRenderer), "set_startColor"), DefIncMinMaxColor, color);

                    int invokeridx = GetComponentInParent(compgetter, typeof(UltEventHolder));

                    evt.PersistentCallsList.AddRunMethod(m_invokeholder, invokeridx);

                    var evtNext3 = node.FlowOutputs[0].Target?.Node;
                    if (evtNext3 != null)
                        evtNext3.Book.CompileNode(evt, evtNext3, dataRoot);
                } break;
            case "makeEvent":
                {
                    ParentToTransform(APIPATH + "MakeEvent/args/args");

                    int pallet = GetComponentInParent(compgetter, typeof(XRInteractorAffordanceStateProvider));
                    evt.PersistentCallsList.AddRunMethod(m_setsource, pallet,
                        new PersistentArgument()
                            .FSetType(PersistentArgumentType.Object)
                            .FSetString(typeof(UObject).AssemblyQualifiedName)
                            .FSetObject(node.DataInputs[0].DefaultObject));

                    int name = GetComponentInParent(compgetter, typeof(Text));
                    evt.PersistentCallsList.AddRunMethod(m_settext, name,
                        new PersistentArgument()
                            .FSetType(PersistentArgumentType.String)
                            .FSetString(node.DataInputs[1].DefaultStringValue));

                    int color = GetComponentInParent(compgetter, typeof(SpriteRenderer));

                    var colorevt = new PersistentArgument().FSetType(PersistentArgumentType.Color);
                    colorevt.Color = node.DataInputs[2].DefaultColorValue;
                    evt.PersistentCallsList.AddRunMethod(FindGetSet(typeof(SpriteRenderer), "set_color"), color, colorevt);

                    int invokeridx = GetComponentInParent(compgetter, typeof(UltEventHolder));

                    evt.PersistentCallsList.AddRunMethod(m_invokeholder, invokeridx);

                    var evtNext3 = node.FlowOutputs[0].Target?.Node;
                    if (evtNext3 != null)
                        evtNext3.Book.CompileNode(evt, evtNext3, dataRoot);
                } break;
            case "makeFloat":
                {
                    ParentToTransform(APIPATH + "MakeFloat/args");

                    int pallet = GetComponentInParent(compgetter, typeof(XRInteractorAffordanceStateProvider));
                    evt.PersistentCallsList.AddRunMethod(m_setsource, pallet,
                        new PersistentArgument()
                            .FSetType(PersistentArgumentType.Object)
                            .FSetString(typeof(UObject).AssemblyQualifiedName)
                            .FSetObject(node.DataInputs[0].DefaultObject));

                    int name = GetComponentInParent(compgetter, typeof(Text));
                    evt.PersistentCallsList.AddRunMethod(m_settext, name,
                        new PersistentArgument()
                            .FSetType(PersistentArgumentType.String)
                            .FSetString(node.DataInputs[1].DefaultStringValue));

                    int Color = GetComponentInParent(compgetter, typeof(Text));
                    var col = new PersistentArgument().FSetType(PersistentArgumentType.Color);
                    col.Color = node.DataInputs[6].DefaultColorValue;
                    evt.PersistentCallsList.AddRunMethod(FindGetSet(typeof(Text), "set_color"), Color, col);

                    int box = GetComponentInParent(compgetter, typeof(BoxCollider));
                    var IncMinMax = new PersistentArgument().FSetType(PersistentArgumentType.Vector3);
                    IncMinMax.Vector3 = new Vector3(
                        node.DataInputs[3].DefaultFloatValue,
                        node.DataInputs[4].DefaultFloatValue,
                        node.DataInputs[5].DefaultFloatValue);
                    evt.PersistentCallsList.AddRunMethod(FindGetSet(typeof(BoxCollider), "set_size"), box, IncMinMax);

                    var Def = new PersistentArgument().FSetType(PersistentArgumentType.Vector3);
                    Def.Vector3 = new Vector3(
                        node.DataInputs[2].DefaultFloatValue,
                        0,
                        0);
                    evt.PersistentCallsList.AddRunMethod(FindGetSet(typeof(BoxCollider), "set_center"), box, Def);

                    int invokeridx = GetComponentInParent(compgetter, typeof(UltEventHolder));

                    evt.PersistentCallsList.AddRunMethod(m_invokeholder, invokeridx);

                    var evtNext3 = node.FlowOutputs[0].Target?.Node;
                    if (evtNext3 != null)
                        evtNext3.Book.CompileNode(evt, evtNext3, dataRoot);
                } break;
            case "makeEnum":
                {
                    ParentToTransform(APIPATH + "MakeEnum/args");

                    int pallet = GetComponentInParent(compgetter, typeof(XRInteractorAffordanceStateProvider));
                    evt.PersistentCallsList.AddRunMethod(m_setsource, pallet,
                        new PersistentArgument()
                            .FSetType(PersistentArgumentType.Object)
                            .FSetString(typeof(UObject).AssemblyQualifiedName)
                            .FSetObject(node.DataInputs[0].DefaultObject));

                    int name = GetComponentInParent(compgetter, typeof(Text));
                    evt.PersistentCallsList.AddRunMethod(m_settext, name,
                        new PersistentArgument()
                            .FSetType(PersistentArgumentType.String)
                            .FSetString(node.DataInputs[1].DefaultStringValue));

                    var def = new PersistentArgument().FSetType(PersistentArgumentType.Int);
                    def.Int = node.DataInputs[2].DefaultIntValue;
                    evt.PersistentCallsList.AddRunMethod(FindGetSet(typeof(Text), "set_fontSize"), name, def);

                    int values = GetComponentInParent(compgetter, typeof(TextMesh));
                    var val = new PersistentArgument().FSetType(PersistentArgumentType.String);
                    var sarr = $"[{node.DataInputs[3].DefaultStringValue}]";
                    var made = Newtonsoft.Json.JsonConvert.DeserializeObject<string[]>(sarr);
                    if (made.Length < 2)
                        throw new ArgumentException($"Provided enum value array was too small, the array must include at least 2 enum values");

                    val.String = sarr;
                    evt.PersistentCallsList.AddRunMethod(FindGetSet(typeof(TextMesh), "set_text"), values, val);

                    int Color = GetComponentInParent(compgetter, typeof(Text));
                    var col = new PersistentArgument().FSetType(PersistentArgumentType.Color);
                    col.Color = node.DataInputs[4].DefaultColorValue;
                    evt.PersistentCallsList.AddRunMethod(FindGetSet(typeof(Text), "set_color"), Color, col);

                    int invokeridx = GetComponentInParent(compgetter, typeof(UltEventHolder));

                    evt.PersistentCallsList.AddRunMethod(m_invokeholder, invokeridx);

                    var evtNext3 = node.FlowOutputs[0].Target?.Node;
                    if (evtNext3 != null)
                        evtNext3.Book.CompileNode(evt, evtNext3, dataRoot);
                }
                break;
            case "notify":
                {
                    ParentToTransform(APIPATH + "NotificationManager/Queue/Push/args");

                    int text = GetComponentInParent(compgetter, typeof(Text));
                    AddRunMethod(m_settext, text,
                        new PersistentArgument[] { new PersistentArgument()
                            .FSetType(PersistentArgumentType.String)
                            .FSetString(node.DataInputs[0].DefaultStringValue) }, node.DataInputs[0]);

                    int textmesh = GetComponentInParent(compgetter, typeof(TextMesh));
                    AddRunMethod(FindGetSet(typeof(TextMesh), "set_text"), textmesh,
                        new PersistentArgument[] { new PersistentArgument()
                            .FSetType(PersistentArgumentType.String)
                            .FSetString(node.DataInputs[1].DefaultStringValue) }, node.DataInputs[1]);

                    AddRunMethod(FindGetSet(typeof(Text), "set_fontSize"), text,
                        new PersistentArgument[] { new PersistentArgument()
                            .FSetType(PersistentArgumentType.Int)
                            .FSetInt(node.DataInputs[2].DefaultIntValue) }, node.DataInputs[2]);

                    var sethold = new PersistentArgument().FSetType(PersistentArgumentType.Float);
                    sethold.Float = node.DataInputs[3].DefaultFloatValue;

                    AddRunMethod(FindGetSet(typeof(Text), "set_lineSpacing"), text,
                        new PersistentArgument[] { sethold }, node.DataInputs[3]);

                    int invokeridx = GetComponentInParent(compgetter, typeof(UltEventHolder));

                    evt.PersistentCallsList.AddRunMethod(m_invokeholder, invokeridx);

                    var evtNext3 = node.FlowOutputs[0].Target?.Node;
                    if (evtNext3 != null)
                        evtNext3.Book.CompileNode(evt, evtNext3, dataRoot);
                } break;
            case "makeUiSpacing":
                {
                    ParentToTransform(APIPATH + "MakeUISpacing/args");

                    int pallet = GetComponentInParent(compgetter, typeof(XRInteractorAffordanceStateProvider));
                    evt.PersistentCallsList.AddRunMethod(m_setsource, pallet,
                        new PersistentArgument()
                            .FSetType(PersistentArgumentType.Object)
                            .FSetString(typeof(UObject).AssemblyQualifiedName)
                            .FSetObject(node.DataInputs[0].DefaultObject));

                    int invokeridx = GetComponentInParent(compgetter, typeof(UltEventHolder));

                    evt.PersistentCallsList.AddRunMethod(m_invokeholder, invokeridx);

                    var evtNext3 = node.FlowOutputs[0].Target?.Node;
                    if (evtNext3 != null)
                        evtNext3.Book.CompileNode(evt, evtNext3, dataRoot);
                } break;
            case "makeUiTitle":
                {
                    ParentToTransform(APIPATH + "MakeUIText/args");

                    int pallet = GetComponentInParent(compgetter, typeof(XRInteractorAffordanceStateProvider));
                    evt.PersistentCallsList.AddRunMethod(m_setsource, pallet,
                        new PersistentArgument()
                            .FSetType(PersistentArgumentType.Object)
                            .FSetString(typeof(UObject).AssemblyQualifiedName)
                            .FSetObject(node.DataInputs[0].DefaultObject));

                    int text = GetComponentInParent(compgetter, typeof(Text));
                    evt.PersistentCallsList.AddRunMethod(m_settext, text,
                        new PersistentArgument()
                            .FSetType(PersistentArgumentType.String)
                            .FSetString(node.DataInputs[1].DefaultStringValue));

                    var color = new PersistentArgument().FSetType(PersistentArgumentType.Color);
                    color.Color = node.DataInputs[2].DefaultColorValue;
                    evt.PersistentCallsList.AddRunMethod(FindGetSet(typeof(Text), "set_color"), text, color);

                    int invokeridx = GetComponentInParent(compgetter, typeof(UltEventHolder));

                    evt.PersistentCallsList.AddRunMethod(m_invokeholder, invokeridx);

                    var evtNext3 = node.FlowOutputs[0].Target?.Node;
                    if (evtNext3 != null)
                        evtNext3.Book.CompileNode(evt, evtNext3, dataRoot);
                }
                break;
            case "harmonyPatchPrefix": { harmonyPatch(false); break; }
            case "harmonyPatchPostfix": { harmonyPatch(true); break; }
            case "harmonyInvokeOriginal":
                {
                    Mask target = dataRoot.GetComponent<Mask>();

                    if (target == null) throw new Exception("Could not find current harmony patch event");

                    var setmethod = new PersistentCall(m_setshowmask, target);
                    setmethod.FSetArguments(new PersistentArgument().FSetType(PersistentArgumentType.Bool).FSetInt(node.DataInputs[0].DefaultBoolValue ? 1 : 0));
                    if (node.DataInputs[0].Source != null)
                        new PendingConnection(node.DataInputs[0].Source, evt, setmethod, 0).Connect(dataRoot);

                    evt.PersistentCallsList.Add(setmethod);
                } break;
            case "opnot":
                {
                    node.DataOutputs[0].CompEvt = evt;
                    node.DataOutputs[0].CompCall = evt.PersistentCallsList[AddNot(0, node.DataInputs[0])];
                    var evtNext = node.FlowOutputs[0].Target?.Node;
                    if (evtNext != null)
                        evtNext.Book.CompileNode(evt, evtNext, dataRoot);
                } break;
            case "opand":
                {
                    node.DataOutputs[0].CompEvt = evt;
                    node.DataOutputs[0].CompCall = evt.PersistentCallsList[AddAnd(0, 0, node.DataInputs[0], node.DataInputs[1])];
                    var evtNext = node.FlowOutputs[0].Target?.Node;
                    if (evtNext != null)
                        evtNext.Book.CompileNode(evt, evtNext, dataRoot);
                } break;
            case "opor":
                {
                    node.DataOutputs[0].CompEvt = evt;
                    node.DataOutputs[0].CompCall = evt.PersistentCallsList[AddOr(0, 0, node.DataInputs[0], node.DataInputs[1])];
                    var evtNext = node.FlowOutputs[0].Target?.Node;
                    if (evtNext != null)
                        evtNext.Book.CompileNode(evt, evtNext, dataRoot);
                } break;
            case "opxor":
                {
                    node.DataOutputs[0].CompEvt = evt;
                    node.DataOutputs[0].CompCall = evt.PersistentCallsList[AddXor(0, 0, node.DataInputs[0], node.DataInputs[1])];
                    var evtNext = node.FlowOutputs[0].Target?.Node;
                    if (evtNext != null)
                        evtNext.Book.CompileNode(evt, evtNext, dataRoot);
                } break;
            case "opisnull":
                {
                    node.DataOutputs[0].CompEvt = evt;
                    node.DataOutputs[0].CompCall = evt.PersistentCallsList[AddIsNull(0, node.DataInputs[0])];
                    var evtNext = node.FlowOutputs[0].Target?.Node;
                    if (evtNext != null)
                        evtNext.Book.CompileNode(evt, evtNext, dataRoot);
                } break;
        }

        var call_parent = new PersistentCall(tr.GetMethod("SetParent", UltEventUtils.AnyAccessBindings, null, new Type[] { typeof(Transform) }, null), compgetter);
        call_parent.PersistentArguments[0].Object = dataRoot;
        if (node.BookTag != "isSpawnedWithLabLib" && !node.BookTag.Contains("harmony") && !node.BookTag.Contains("op"))
            evt.PersistentCallsList.Add(call_parent);
        prevdataroot = dataRoot;
    }

    public override void PostCompile(SerializedBowl bowl)
    {

    }
}
#endif
