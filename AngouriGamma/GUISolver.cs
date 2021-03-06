﻿using AngouriMath;
using System.Threading;
using System.Threading.Tasks;

namespace AngouriGamma
{
    public sealed class GUISolver
    {
        public int Timeout { get; set; }
        private CancellationTokenSource lastTokenSource;
        public async Task<Entity> Solve(Entity expr, Entity.Variable @var)
        {
            if (lastTokenSource is not null)
                lastTokenSource.Cancel();
            var tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(Timeout);
            lastTokenSource = tokenSource;
            return await Task.Run(
                    () =>
                    {
                        MathS.Multithreading.SetLocalCancellationToken(tokenSource.Token);
                        if (expr is Entity.Statement)
                            return expr.Solve(@var).Simplify();
                        return MathS.Equality(expr, 0).Solve(@var).Simplify();
                    }, tokenSource.Token
                    ).ContinueWith(t => t.IsCanceled ? "Timeout" : t.Result);
        }
    }
}
