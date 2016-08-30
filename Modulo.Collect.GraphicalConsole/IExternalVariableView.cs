﻿#region License
/* * Modulo Open Distributed SCAP Infrastructure Collector (modSIC)
 * 
 * Copyright (c) 2011-2015, Modulo Solutions for GRC.
 * All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 * 
 * - Redistributions of source code must retain the above copyright notice,
 *   this list of conditions and the following disclaimer.
 *   
 * - Redistributions in binary form must reproduce the above copyright 
 *   notice, this list of conditions and the following disclaimer in the
 *   documentation and/or other materials provided with the distribution.
 *   
 * - Neither the name of Modulo Security, LLC nor the names of its
 *   contributors may be used to endorse or promote products derived from
 *   this software without specific  prior written permission.
 *   
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 * */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modulo.Collect.OVAL.Definitions;

namespace Modulo.Collect.GraphicalConsole
{
    public interface IExternalVariableView
    {
        void AddControl(Control control);
        void AddControlWithLabel(Label[] label, Control control);

        event EventHandler<CreateControlsEventArgs> OnCreateControls;
        event EventHandler<ExternalVariableEventArgs> OnGetExternalVariables;
        event EventHandler<ValidateEventArgs> OnValidate;
        event EventHandler<OnXCCDFEventArgs> OnXCCDF;

        float Progress { get; set; }
    }

    public class ValidateEventArgs : EventArgs
    {
        public VariablesTypeVariableExternal_variable Variable { get; set; }
        public string Value { get; set; }
        public string ErrorMessage { get; set; }
        public bool Result { get; set; }
    }

    public class CreateControlsEventArgs : EventArgs
    {
        public IEnumerable<VariablesTypeVariableExternal_variable> Variables { get; set; }
        public Dictionary<String, String> Values { get; set; }
        public bool Result { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class ExternalVariableEventArgs : EventArgs
    {
        public IEnumerable<VariablesTypeVariableExternal_variable> ExternalVariables { get; set; }
        public Dictionary<String, String> Values { get; set; }
        public String Xml { get; set; }
    }

    public class OnXCCDFEventArgs : EventArgs
    {
        public string Filename { get; set; }
    }
}
