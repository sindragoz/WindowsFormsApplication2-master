using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MusicPlayer
{
    class ComponentPositionEditor : System.Drawing.Design.UITypeEditor
    {

        private IWindowsFormsEditorService edSvc = null;
        protected virtual void SetEditorProps(MusicPlayer editingInstance, CompEditPanel editor)
        {
            editor.Size = new Size(editingInstance.Width, editingInstance.Height);
        }
        int i = 0;
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            
            if (context != null
                && context.Instance != null
                && provider != null)
            {

                edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

                if (edSvc != null)
                {
                    List<Rectangle> comp_rect_list = new List<Rectangle>();
                    Control cont = new Control() ;
                    foreach (var c in (context.Instance as MusicPlayer).Controls)
                        if ((c as Control).Location != ((Rectangle)value).Location)
                        {
                            comp_rect_list.Add(new Rectangle((c as Control).Location, (c as Control).Size));
                        }
                        else {
                            cont = c as Control;
                        }
                    
                    CompEditPanel pan = new CompEditPanel((Rectangle)value,comp_rect_list, (context.Instance as MusicPlayer).Theme);
                    
                    pan.Theme = (context.Instance as MusicPlayer).Theme;
                    SetEditorProps((MusicPlayer)context.Instance, pan);
                        edSvc.DropDownControl(pan);
                        if ((cont as Control) is buttonPlay.NextBtn) { (context.Instance as MusicPlayer).Next_clr = pan.Element_color;  }
                        if ((cont as Control) is buttonPlay.PlayBtn) { (context.Instance as MusicPlayer).Play_clr = pan.Element_color;  }
                        if ((cont as Control) is buttonPlay.PrevBtn) { (context.Instance as MusicPlayer).Prev_clr = pan.Element_color;  }
                        if ((cont as Control) is MusicList.MusicList) { (context.Instance as MusicPlayer).Mus_list_clr = pan.Element_color; }
                        if ((cont as Control) is SoundTrackBar.MusicTrackBar) { (context.Instance as MusicPlayer).Mus_bar_clr = pan.Element_color; }
                        if ((cont as Control) is SoundTrackBar.RoundedTrackBar) { (context.Instance as MusicPlayer).Rounded_bar_clr = pan.Element_color; }
                        if ((cont as Control) is SoundTrackBar.VolumeTrackBar) { (context.Instance as MusicPlayer).Volume_clr = pan.Element_color; }
                        if ((cont as Control) is SoundSpectrumVisualisation.SoundSpectrum) { (context.Instance as MusicPlayer).Spectrum_clr = pan.Element_color; }
                        if ((cont as Control) is Label) { (context.Instance as MusicPlayer).Count_time_clr = pan.Element_color; }
                        if ((cont as Control) is buttonPlay.LoadFileBtn) {(context.Instance as MusicPlayer).File_img = pan.Element_image; }
                        if ((cont as Control) is buttonPlay.MusicListBtn) { (context.Instance as MusicPlayer).Muslist_img = pan.Element_image; }
                        if ((cont as Control) is buttonPlay.SpectreBtn) { (context.Instance as MusicPlayer).Spectrum_img = pan.Element_image; }
                        if ((cont as Control) is buttonPlay.ChangeStyleBtn) { (context.Instance as MusicPlayer).Sytle_img = pan.Element_image; }
                    return pan.getComp();
                }
            }
            return null;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                return UITypeEditorEditStyle.DropDown;
            }
            return base.GetEditStyle(context);
        }
        private void ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
