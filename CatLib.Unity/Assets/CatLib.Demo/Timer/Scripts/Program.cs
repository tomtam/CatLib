﻿/*
 * This file is part of the CatLib package.
 *
 * (c) Yu Bin <support@catlib.io>
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * Document: http://catlib.io/
 */

using CatLib.Events;
using CatLib.Time;
using CatLib.Timer;
using System;
using CatLib.MonoDriver;

namespace CatLib.Demo.Timer
{
    /**
     * 这个类提供了当前demo演示时用到的组件 
     */
    public class Bootstraps : IBootstrap
    {

        public void Bootstrap()
        {
            App.Register(new EventsProvider());
            App.Register(new TimerProvider());
            App.Register(new TimeProvider());
            App.Register(new TimerDemo());
            App.Register(new MonoDriverProvider());
        }

    }

    /**
     * 这个类是入口类用于启动框架 
     */
    public class Program : UnityEngine.MonoBehaviour
    {
        public void Awake()
        {
            var application = new Application(this);
            application.OnFindType((type) =>
            {
                return Type.GetType(type);
            });
            application.Bootstrap(new Bootstraps()).Init();
        }
    }

}