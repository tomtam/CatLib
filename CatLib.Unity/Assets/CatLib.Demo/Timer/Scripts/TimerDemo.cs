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

using CatLib.API.Timer;
using UnityEngine;

namespace CatLib.Demo.Timer
{
    /// <summary>
    /// 计时器Demo
    /// </summary>
    public class TimerDemo : IServiceProvider
    {
        public void Init()
        {
            App.On(ApplicationEvents.OnStartComplete, (payload) =>
            {
                var timerManager = App.Make<ITimerManager>();

                Debug.Log("frame count: " + UnityEngine.Time.frameCount);

                var statu = 0;
                timerManager.Make(() =>
                {
                    Debug.Log("tick: " + (++statu) + " / " + UnityEngine.Time.frameCount);
                }).IntervalFrame(2);

                timerManager.Make(() =>
                {
                    Debug.Log("delay tick: " + (++statu) + " / " + UnityEngine.Time.frameCount);
                }).DelayFrame(1);

                timerManager.Make(() =>
                {
                    Debug.Log("loop frame tick: " + (++statu) + " / " + UnityEngine.Time.frameCount);
                }).LoopFrame(3);
            });
        }

        public void Register()
        {

        }
    }
}
