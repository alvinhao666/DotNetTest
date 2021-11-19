////////////////////////////////////////////////////////////////////
//                          _ooOoo_                               //
//                         o8888888o                              //
//                         88" . "88                              //
//                         (| ^_^ |)                              //
//                         O\  =  /O                              //
//                      ____/`---'\____                           //
//                    .'  \\|     |//  `.                         //
//                   /  \\|||  :  |||//  \                        //
//                  /  _||||| -:- |||||-  \                       //
//                  |   | \\\  -  /// |   |                       //
//                  | \_|  ''\---/''  |   |                       //
//                  \  .-\__  `-`  ___/-. /                       //
//                ___`. .'  /--.--\  `. . ___                     //
//              ."" '<  `.___\_<|>_/___.'  >'"".                  //
//            | | :  `- \`.;`\ _ /`;.`/ - ` : | |                 //
//            \  \ `-.   \_ __\ /__ _/   .-` /  /                 //
//      ========`-.____`-.___\_____/___.-`____.-'========         //
//                           `=---='                              //
//      ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^        //
//              佛祖保佑       永不宕机     永无BUG                   //
////////////////////////////////////////////////////////////////////

try
{
    try
    {
        var num = int.Parse("abc");
    }
    catch (Exception inner)
    {
        try
        {
            var openLog = File.Open("DoesNotExist", FileMode.Open);
        }
        catch
        {
            throw new FileNotFoundException("OutterException", inner);
        }
    }
}
catch (Exception e)
{
    string inMes, outMes;
    if (e.InnerException != null)
        inMes = e.InnerException.Message;
    outMes = e.Message;
}


Console.ReadKey();
