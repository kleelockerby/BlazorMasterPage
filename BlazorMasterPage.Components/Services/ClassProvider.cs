using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMasterPage.Components.Services
{
    public abstract class ClassProvider : IClassProvider
    {
        public abstract bool UseCustomInputStyles { get; set; }
        public abstract string Provider { get; }

        public abstract string TextEdit(bool plaintext);

        public abstract string TextEditSize(Size size);

        public abstract string TextEditColor(Color color);

        public abstract string TextEditValidation(ValidationStatus validationStatus);

        public abstract string MemoEdit();

        public abstract string MemoEditValidation(ValidationStatus validationStatus);

        public abstract string Select();

        public abstract string SelectMultiple();

        public abstract string SelectSize(Size size);

        public abstract string SelectValidation(ValidationStatus validationStatus);

        public abstract string NumericEdit(bool plaintext);

        public abstract string NumericEditSize(Size size);

        public abstract string NumericEditColor(Color color);

        public abstract string NumericEditValidation(ValidationStatus validationStatus);

        public abstract string DateEdit(bool plaintext);

        public abstract string DateEditSize(Size size);

        public abstract string DateEditColor(Color color);

        public abstract string DateEditValidation(ValidationStatus validationStatus);

        public abstract string TimeEdit(bool plaintext);

        public abstract string TimeEditSize(Size size);

        public abstract string TimeEditColor(Color color);

        public abstract string TimeEditValidation(ValidationStatus validationStatus);

        public abstract string ColorEdit();

        public abstract string Check();

        public abstract string CheckSize(Size size);

        public abstract string CheckInline();

        public abstract string CheckCursor(Cursor cursor);

        public abstract string CheckValidation(ValidationStatus validationStatus);

        public abstract string RadioGroup(bool buttons, Orientation orientation);

        public abstract string RadioGroupValidation(ValidationStatus validationStatus);

        public abstract string Radio(bool button);

        public abstract string RadioSize(bool button, Size size);

        public abstract string RadioInline(bool inline);

        public abstract string RadioCursor(Cursor cursor);

        public abstract string RadioValidation(ValidationStatus validationStatus);

        public abstract string Switch();

        public abstract string SwitchColor(Color color);

        public abstract string SwitchSize(Size size);

        public abstract string SwitchChecked(bool @checked);

        public abstract string SwitchCursor(Cursor cursor);

        public abstract string SwitchValidation(ValidationStatus validationStatus);

        public abstract string FileEdit();

        public abstract string FileEditValidation(ValidationStatus validationStatus);

        public abstract string Slider();

        public abstract string SliderColor(Color color);

        public abstract string Label();

        public abstract string LabelType(LabelType labelType);

        public abstract string LabelCursor(Cursor cursor);

        public abstract string Help();

        public abstract string ValidationSuccess();

        public abstract string ValidationSuccessTooltip();

        public abstract string ValidationError();

        public abstract string ValidationErrorTooltip();

        public abstract string ValidationNone();

        public abstract string ValidationSummary();

        public abstract string ValidationSummaryError();

        public abstract string Fields();

        public abstract string FieldsBody();

        public abstract string FieldsColumn();

        public abstract string Field();

        public abstract string FieldHorizontal();

        public abstract string FieldColumn();

        public abstract string FieldJustifyContent(JustifyContent justifyContent);

        public abstract string FieldValidation(ValidationStatus validationStatus);

        public abstract string FieldLabel();

        public abstract string FieldLabelHorizontal();

        public abstract string FieldBody();

        public abstract string FieldHelp();

        public abstract string ControlCheck();

        public abstract string ControlRadio();

        public abstract string ControlSwitch();

        public abstract string ControlFile();

        public abstract string ControlText();

        public abstract string Addons();

        public abstract string AddonsHasButton(bool hasButton);

        public abstract string Addon(AddonType addonType);

        public abstract string AddonLabel();

        //public abstract string AddonContainer();

        public abstract string Inline();

        public abstract string Button();

        public abstract string ButtonColor(Color color);

        public abstract string ButtonOutline(Color color);

        public abstract string ButtonSize(Size size);

        public abstract string ButtonBlock();

        public abstract string ButtonActive();

        public abstract string ButtonLoading();

        //public abstract string Buttons();

        public abstract string ButtonsAddons();

        public abstract string ButtonsToolbar();

        public abstract string ButtonsSize(Size size);

        public abstract string ButtonsOrientation(Orientation orientation);

        public abstract string CloseButton();

        public abstract string Dropdown();

        public abstract string DropdownGroup();

        public abstract string DropdownShow();

        public abstract string DropdownRight();

        public abstract string DropdownItem();

        public abstract string DropdownItemActive(bool active);

        public abstract string DropdownItemDisabled(bool disabled);

        public abstract string DropdownDivider();

        public abstract string DropdownMenu();

        //public abstract string DropdownMenuBody();

        public abstract string DropdownMenuVisible(bool visible);

        public abstract string DropdownMenuRight();

        public abstract string DropdownToggle();

        public abstract string DropdownToggleColor(Color color);

        public abstract string DropdownToggleOutline(Color color);

        public abstract string DropdownToggleSize(Size size);

        public abstract string DropdownToggleSplit();

        public abstract string DropdownToggleIcon(bool visible);

        public abstract string DropdownDirection(Direction direction);

        public abstract string DropdownTableResponsive();

        public abstract string Tabs(bool pills);

        public abstract string TabsCards();

        public abstract string TabsFullWidth();

        public abstract string TabsJustified();

        public abstract string TabsVertical();

        public abstract string TabItem();

        public abstract string TabItemActive(bool active);

        public abstract string TabItemDisabled(bool disabled);

        public abstract string TabLink();

        public abstract string TabLinkActive(bool active);

        public abstract string TabLinkDisabled(bool disabled);

        public abstract string TabsContent();

        public abstract string TabPanel();

        public abstract string TabPanelActive(bool active);

        public abstract string Steps();

        public abstract string StepItem();

        public abstract string StepItemActive(bool active);

        public abstract string StepItemCompleted(bool completed);

        public abstract string StepItemColor(Color color);

        public abstract string StepItemMarker();

        public abstract string StepItemDescription();

        public abstract string StepsContent();

        public abstract string StepPanel();

        public abstract string StepPanelActive(bool active);

        public abstract string Carousel();

        public abstract string CarouselSlides();

        public abstract string CarouselSlide();

        public abstract string CarouselSlideActive(bool active);

        public abstract string CarouselIndicators();

        public abstract string CarouselIndicator();

        public abstract string CarouselIndicatorActive(bool active);

        public abstract string CarouselFade(bool fade);

        public abstract string CarouselCaption();

        public abstract string Jumbotron();

        public abstract string JumbotronBackground(Background background);

        public abstract string JumbotronTitle(JumbotronTitleSize jumbotronTitleSize);

        public abstract string JumbotronSubtitle();

        public abstract string CardDeck();

        public abstract string CardGroup();

        public abstract string Card();

        public abstract string CardWhiteText();

        public abstract string CardBackground(Background background);

        public abstract string CardActions();

        public abstract string CardBody();

        public abstract string CardFooter();

        public abstract string CardHeader();

        public abstract string CardImage();

        public abstract string CardTitle(bool insideHeader);

        public abstract string CardTitleSize(bool insideHeader, int? size);

        public abstract string CardSubtitle(bool insideHeader);

        public abstract string CardSubtitleSize(bool insideHeader, int size);

        public abstract string CardText();

        public abstract string CardLink();

        public abstract string ListGroup();

        public abstract string ListGroupFlush();

        public abstract string ListGroupItem();

        public abstract string ListGroupItemActive();

        public abstract string ListGroupItemDisabled();

        public virtual string Layout() => "b-layout";

        public virtual string LayoutHasSider() => "b-layout-has-sider";

        public virtual string LayoutContent() => "b-layout-content";

        public virtual string LayoutHeader() => "b-layout-header";

        public virtual string LayoutHeaderFixed() => "b-layout-header-fixed";

        public virtual string LayoutFooter() => "b-layout-footer";

        public virtual string LayoutFooterFixed() => "b-layout-footer-fixed";

        public virtual string LayoutSider() => "b-layout-sider";

        public virtual string LayoutSiderContent() => "b-layout-sider-content";

        public virtual string LayoutLoading() => "b-layout-loading";

        public virtual string LayoutRoot() => "b-layout-root";

        public abstract string Container();

        public abstract string ContainerFluid();

        public abstract string Bar();

        public abstract string BarBackground(Background background);

        public abstract string BarAlignment(Alignment alignment);

        public abstract string BarBreakpoint(Breakpoint breakpoint);

        public abstract string BarMode(BarMode mode);

        public abstract string BarItem(BarMode mode);

        public abstract string BarItemActive(BarMode mode);

        public abstract string BarItemDisabled(BarMode mode);

        public abstract string BarItemHasDropdown(BarMode mode);

        public abstract string BarItemHasDropdownShow(BarMode mode);

        public abstract string BarLink(BarMode mode);

        public abstract string BarLinkDisabled(BarMode mode);

        //public abstract string BarCollapsed();

        public abstract string BarBrand(BarMode mode);

        public abstract string BarToggler(BarMode mode, BarTogglerMode togglerMode);

        public abstract string BarTogglerCollapsed(BarMode mode, BarTogglerMode togglerMode, bool isShow);

        public abstract string BarMenu(BarMode mode);

        public abstract string BarMenuShow(BarMode mode);

        public abstract string BarStart(BarMode mode);

        public abstract string BarEnd(BarMode mode);

        //public abstract string BarHasDropdown();

        public abstract string BarDropdown(BarMode mode);

        public abstract string BarDropdownShow(BarMode mode);

        public abstract string BarDropdownToggle(BarMode mode);

        public abstract string BarDropdownItem(BarMode mode);

        public abstract string BarTogglerIcon(BarMode mode);

        public abstract string BarDropdownMenu(BarMode mode);

        public abstract string BarDropdownMenuVisible(BarMode mode, bool visible);

        public abstract string BarDropdownMenuRight(BarMode mode);

        public abstract string BarDropdownMenuContainer(BarMode mode);

        public abstract string BarCollapsed(BarMode mode);

        public abstract string BarLabel();

        public abstract string Accordion();

        public abstract string Collapse();

        public abstract string CollapseActive(bool active);

        public abstract string CollapseHeader();

        public abstract string CollapseBody();

        public abstract string CollapseBodyActive(bool active);

        public abstract string CollapseBodyContent();

        public abstract string Row();

        public abstract string Column(bool hasSizes);

        public abstract string Column(ColumnWidth columnWidth, Breakpoint breakpoint, bool offset);

        public virtual string Column(ColumnWidth columnWidth, IEnumerable<(Breakpoint breakpoint, bool offset)> rules) =>
            string.Join(" ", rules.Select(r => Column(columnWidth, r.breakpoint, r.offset)));

        public abstract string Display(DisplayType displayType, Breakpoint breakpoint, DisplayDirection direction);

        public virtual string Display(DisplayType displayType, IEnumerable<(Breakpoint breakpoint, DisplayDirection direction)> rules)
            => string.Join(" ", rules.Select(r => Display(displayType, r.breakpoint, r.direction)));

        public abstract string Alert();

        public abstract string AlertColor(Color color);

        public abstract string AlertDismisable();

        public abstract string AlertFade();

        public abstract string AlertShow();

        public abstract string AlertHasMessage();

        public abstract string AlertHasDescription();

        public abstract string AlertMessage();

        public abstract string AlertDescription();

        public abstract string Modal();

        public abstract string ModalFade();

        public abstract string ModalVisible(bool visible);

        public abstract string ModalBackdrop();

        public abstract string ModalBackdropFade();

        public abstract string ModalBackdropVisible(bool visible);

        public abstract string ModalContent(bool dialog);

        //public abstract string ModalContentSize(ModalSize modalSize);

        public abstract string ModalContentCentered();

        public abstract string ModalBody();

        public abstract string ModalHeader();

        public abstract string ModalFooter();

        public abstract string ModalTitle();

        public abstract string Pagination();

        public abstract string PaginationSize(Size size);

        public abstract string PaginationItem();

        public abstract string PaginationItemActive();

        public abstract string PaginationItemDisabled();

        public abstract string PaginationLink();

        public abstract string PaginationLinkActive();

        public abstract string PaginationLinkDisabled();

        public abstract string Progress();

        public abstract string ProgressSize(Size size);

        public abstract string ProgressBar();

        public abstract string ProgressBarSize(Size size);

        public abstract string ProgressBarColor(Background background);

        public abstract string ProgressBarStriped();

        public abstract string ProgressBarAnimated();

        public abstract string ProgressBarWidth(int width);

        public abstract string Chart();

        public abstract string BackgroundColor(Background color);

        public abstract string Title();

        public abstract string TitleSize(int size);

        public abstract string Table();

        public abstract string TableFullWidth();

        public abstract string TableStriped();

        public abstract string TableHoverable();

        public abstract string TableBordered();

        public abstract string TableNarrow();

        public abstract string TableBorderless();

        public abstract string TableHeader();

        public abstract string TableHeaderCell();

        public abstract string TableHeaderCellTextAlignment(TextAlignment textAlignment);

        public abstract string TableFooter();

        public abstract string TableBody();

        public abstract string TableRow();

        public abstract string TableRowColor(Color color);

        public abstract string TableRowBackground(Background background);

        public abstract string TableRowTextColor(TextColor textColor);

        public abstract string TableRowHoverCursor();

        public abstract string TableRowIsSelected();

        public abstract string TableRowHeader();

        public abstract string TableRowCell();

        public abstract string TableRowCellColor(Color color);

        public abstract string TableRowCellBackground(Background background);

        public abstract string TableRowCellTextColor(TextColor textColor);

        public abstract string TableRowCellTextAlignment(TextAlignment textAlignment);

        public abstract string TableResponsive();

        public abstract string Badge();

        public abstract string BadgeColor(Color color);

        public abstract string BadgePill();

        public abstract string BadgeClose();

        public abstract string Media();

        public abstract string MediaLeft();

        public abstract string MediaRight();

        public abstract string MediaBody();

        public abstract string TextColor(TextColor textColor);

        public abstract string TextAlignment(TextAlignment textAlignment);

        public abstract string TextTransform(TextTransform textTransform);

        public abstract string TextWeight(TextWeight textWeight);

        public abstract string TextItalic();

        public abstract string HeadingSize(HeadingSize headingSize);

        public abstract string DisplayHeadingSize(DisplayHeadingSize displayHeadingSize);

        public abstract string Paragraph();

        public abstract string ParagraphColor(TextColor textColor);

        public abstract string Figure();

        public abstract string FigureSize(FigureSize figureSize);

        public abstract string FigureImage();

        public abstract string FigureImageRounded();

        public abstract string FigureCaption();

        public abstract string Breadcrumb();

        public abstract string BreadcrumbItem();

        public abstract string BreadcrumbItemActive();

        public abstract string BreadcrumbLink();

        public abstract string Tooltip();

        public abstract string TooltipPlacement(Placement placement);

        public abstract string TooltipMultiline();

        public abstract string TooltipAlwaysActive();

        public abstract string TooltipFade();

        public abstract string TooltipInline();

        public abstract string Divider();

        public abstract string DividerType(DividerType dividerType);

        public abstract string Show();

        public abstract string Fade();

        public abstract string Active();

        public abstract string Disabled();

        public abstract string Collapsed();

        public abstract string Spacing(Spacing spacing, SpacingSize spacingSize, Side side, Breakpoint breakpoint);

        public abstract string Spacing(Spacing spacing, SpacingSize spacingSize, IEnumerable<(Side side, Breakpoint breakpoint)> rules);

        public abstract string FlexAlignment(Alignment alignment);

        public virtual string Casing(CharacterCasing characterCasing) => $"b-character-casing-{ToCharacterCasing(characterCasing)}";

        public virtual string ToSize(Size size)
        {
            switch (size)
            {
                case Size.ExtraSmall:
                    return "xs";
                case Size.Small:
                    return "sm";
                case Size.Medium:
                    return "md";
                case Size.Large:
                    return "lg";
                case Size.ExtraLarge:
                    return "xl";
                default:
                    return null;
            }
        }

        public virtual string ToBreakpoint(Breakpoint breakpoint)
        {
            switch (breakpoint)
            {
                case Breakpoint.Mobile:
                    return "xs";
                case Breakpoint.Tablet:
                    return "sm";
                case Breakpoint.Desktop:
                    return "md";
                case Breakpoint.Widescreen:
                    return "lg";
                case Breakpoint.FullHD:
                    return "xl";
                default:
                    return null;
            }
        }

        public virtual string ToColor(Color color)
        {
            switch (color)
            {
                case Color.Primary:
                    return "primary";
                case Color.Secondary:
                    return "secondary";
                case Color.Success:
                    return "success";
                case Color.Danger:
                    return "danger";
                case Color.Warning:
                    return "warning";
                case Color.Info:
                    return "info";
                case Color.Light:
                    return "light";
                case Color.Dark:
                    return "dark";
                case Color.Link:
                    return "link";
                default:
                    return null;
            }
        }

        public virtual string ToBackground(Background color)
        {
            switch (color)
            {
                case Background.Primary:
                    return "primary";
                case Background.Secondary:
                    return "secondary";
                case Background.Success:
                    return "success";
                case Background.Danger:
                    return "danger";
                case Background.Warning:
                    return "warning";
                case Background.Info:
                    return "info";
                case Background.Light:
                    return "light";
                case Background.Dark:
                    return "dark";
                case Background.White:
                    return "white";
                case Background.Transparent:
                    return "transparent";
                default:
                    return null;
            }
        }

        public virtual string ToBarMode(BarMode mode)
        {
            switch (mode)
            {
                case BlazorMasterPage.Components.BarMode.Horizontal:
                    return "horizontal";
                case BlazorMasterPage.Components.BarMode.VerticalPopout:
                    return "vertical-popout";
                case BlazorMasterPage.Components.BarMode.VerticalInline:
                    return "vertical-inline";
                case BlazorMasterPage.Components.BarMode.VerticalSmall:
                    return "vertical-small";
                default:
                    return null;
            }
        }


        public virtual string ToBarCollapsedMode(BarCollapseMode collapseMode)
        {
            switch (collapseMode)
            {
                case BarCollapseMode.Hide:
                    return "hide";
                case BarCollapseMode.Small:
                    return "small";
                default:
                    return null;
            }
        }


        public virtual string ToTextColor(TextColor textColor)
        {
            switch (textColor)
            {
                case BlazorMasterPage.Components.TextColor.Primary:
                    return "primary";
                case BlazorMasterPage.Components.TextColor.Secondary:
                    return "secondary";
                case BlazorMasterPage.Components.TextColor.Success:
                    return "success";
                case BlazorMasterPage.Components.TextColor.Danger:
                    return "danger";
                case BlazorMasterPage.Components.TextColor.Warning:
                    return "warning";
                case BlazorMasterPage.Components.TextColor.Info:
                    return "info";
                case BlazorMasterPage.Components.TextColor.Light:
                    return "light";
                case BlazorMasterPage.Components.TextColor.Dark:
                    return "dark";
                case BlazorMasterPage.Components.TextColor.Body:
                    return "body";
                case BlazorMasterPage.Components.TextColor.Muted:
                    return "muted";
                case BlazorMasterPage.Components.TextColor.White:
                    return "white";
                case BlazorMasterPage.Components.TextColor.Black50:
                    return "black-50";
                case BlazorMasterPage.Components.TextColor.White50:
                    return "white-50";
                default:
                    return null;
            }
        }

        public virtual string ToFloat(Float @float)
        {
            switch (@float)
            {
                case Float.Left:
                    return "float-left";
                case Float.Right:
                    return "float-right";
                default:
                    return null;
            }
        }

        public virtual string ToSpacing(Spacing spacing)
        {
            switch (spacing)
            {
                case BlazorMasterPage.Components.Spacing.Margin:
                    return "m";
                case BlazorMasterPage.Components.Spacing.Padding:
                    return "p";
                default:
                    return null;
            }
        }

        public virtual string ToSide(Side side)
        {
            switch (side)
            {
                case Side.Top:
                    return "t";
                case Side.Bottom:
                    return "b";
                case Side.Left:
                    return "l";
                case Side.Right:
                    return "r";
                case Side.X:
                    return "x";
                case Side.Y:
                    return "y";
                default:
                    return null;
            }
        }

        public virtual string ToAlignment(Alignment alignment)
        {
            switch (alignment)
            {
                case Alignment.Start:
                    return "start";
                case Alignment.Center:
                    return "center";
                case Alignment.End:
                    return "end";
                default:
                    return null;
            }
        }

        public virtual string ToTextAlignment(TextAlignment textAlignment)
        {
            switch (textAlignment)
            {
                case BlazorMasterPage.Components.TextAlignment.Left:
                    return "left";
                case BlazorMasterPage.Components.TextAlignment.Center:
                    return "center";
                case BlazorMasterPage.Components.TextAlignment.Right:
                    return "right";
                case BlazorMasterPage.Components.TextAlignment.Justified:
                    return "justify";
                default:
                    return null;
            }
        }

        public virtual string ToTextTransform(TextTransform textTransform)
        {
            switch (textTransform)
            {
                case BlazorMasterPage.Components.TextTransform.Lowercase:
                    return "lowercase";
                case BlazorMasterPage.Components.TextTransform.Uppercase:
                    return "uppercase";
                case BlazorMasterPage.Components.TextTransform.Capitalize:
                    return "capitalize";
                default:
                    return null;
            }
        }

        public virtual string ToTextWeight(TextWeight textWeight)
        {
            switch (textWeight)
            {
                case BlazorMasterPage.Components.TextWeight.Normal:
                    return "normal";
                case BlazorMasterPage.Components.TextWeight.Bold:
                    return "bold";
                case BlazorMasterPage.Components.TextWeight.Light:
                    return "light";
                default:
                    return null;
            }
        }

        public virtual string ToColumnWidth(ColumnWidth columnWidth)
        {
            switch (columnWidth)
            {
                case ColumnWidth.Is1:
                    return "1";
                case ColumnWidth.Is2:
                    return "2";
                case ColumnWidth.Is3:
                case ColumnWidth.Quarter:
                    return "3";
                case ColumnWidth.Is4:
                case ColumnWidth.Third:
                    return "4";
                case ColumnWidth.Is5:
                    return "5";
                case ColumnWidth.Is6:
                case ColumnWidth.Half:
                    return "6";
                case ColumnWidth.Is7:
                    return "7";
                case ColumnWidth.Is8:
                    return "8";
                case ColumnWidth.Is9:
                    return "9";
                case ColumnWidth.Is10:
                    return "10";
                case ColumnWidth.Is11:
                    return "11";
                case ColumnWidth.Is12:
                case ColumnWidth.Full:
                    return "12";
                case ColumnWidth.Auto:
                    return "auto";
                default:
                    return null;
            }
        }

        public virtual string ToDisplayType(DisplayType displayType)
        {
            switch (displayType)
            {
                case DisplayType.None:
                    return "none";
                case DisplayType.Block:
                    return "block";
                case DisplayType.Inline:
                    return "inline";
                case DisplayType.InlineBlock:
                    return "inline-block";
                case DisplayType.Flex:
                    return "flex";
                case DisplayType.InlineFlex:
                    return "inline-flex";
                case DisplayType.Table:
                    return "table";
                case DisplayType.TableRow:
                    return "table-row";
                case DisplayType.TableCell:
                    return "table-cell";
                case DisplayType.Always:
                default:
                    return null;
            }
        }

        public virtual string ToDisplayDirection(DisplayDirection displayDirection)
        {
            switch (displayDirection)
            {
                case DisplayDirection.Row:
                    return "row";
                case DisplayDirection.Column:
                    return "column";
                case DisplayDirection.ReverseRow:
                    return "row-reverse";
                case DisplayDirection.ReverseColumn:
                    return "column-reverse";
                default:
                    return null;
            }
        }

        /*public virtual string ToModalSize(ModalSize modalSize)
        {
            switch (modalSize)
            {
                case ModalSize.Small:
                    return "sm";
                case ModalSize.Large:
                    return "lg";
                case ModalSize.ExtraLarge:
                    return "xl";
                case ModalSize.Default:
                default:
                    return null;
            }
        }*/

        public virtual string ToSpacingSize(SpacingSize spacingSize)
        {
            switch (spacingSize)
            {
                case SpacingSize.Is0:
                    return "0";
                case SpacingSize.Is1:
                    return "1";
                case SpacingSize.Is2:
                    return "2";
                case SpacingSize.Is3:
                    return "3";
                case SpacingSize.Is4:
                    return "4";
                case SpacingSize.Is5:
                    return "5";
                case SpacingSize.IsAuto:
                    return "auto";
                default:
                    return null;
            }
        }

        public virtual string ToJustifyContent(JustifyContent justifyContent)
        {
            switch (justifyContent)
            {
                case JustifyContent.Start:
                    return "justify-content-start";
                case JustifyContent.End:
                    return "justify-content-end";
                case JustifyContent.Center:
                    return "justify-content-center";
                case JustifyContent.Between:
                    return "justify-content-between";
                case JustifyContent.Around:
                    return "justify-content-around";
                default:
                    return null;
            }
        }

        /*public virtual string ToScreenreader(Screenreader screenreader)
        {
            switch (screenreader)
            {
                case Screenreader.Only:
                    return "sr-only";
                case Screenreader.OnlyFocusable:
                    return "sr-only-focusable";
                default:
                    return null;
            }
        }*/

        public virtual string ToHeadingSize(HeadingSize headingSize)
        {
            switch (headingSize)
            {
                case BlazorMasterPage.Components.HeadingSize.Is1:
                    return "1";
                case BlazorMasterPage.Components.HeadingSize.Is2:
                    return "2";
                case BlazorMasterPage.Components.HeadingSize.Is3:
                    return "3";
                case BlazorMasterPage.Components.HeadingSize.Is4:
                    return "4";
                case BlazorMasterPage.Components.HeadingSize.Is5:
                    return "5";
                case BlazorMasterPage.Components.HeadingSize.Is6:
                    return "6";
                default:
                    return null;
            }
        }

        public virtual string ToDisplayHeadingSize(DisplayHeadingSize displayHeadingSize)
        {
            switch (displayHeadingSize)
            {
                case BlazorMasterPage.Components.DisplayHeadingSize.Is1:
                    return "1";
                case BlazorMasterPage.Components.DisplayHeadingSize.Is2:
                    return "2";
                case BlazorMasterPage.Components.DisplayHeadingSize.Is3:
                    return "3";
                case BlazorMasterPage.Components.DisplayHeadingSize.Is4:
                    return "4";
                default:
                    return null;
            }
        }

        public virtual string ToJumbotronTitleSize(JumbotronTitleSize jumbotronTitleSize)
        {
            switch (jumbotronTitleSize)
            {
                case JumbotronTitleSize.Is1:
                    return "1";
                case JumbotronTitleSize.Is2:
                    return "2";
                case JumbotronTitleSize.Is3:
                    return "3";
                case JumbotronTitleSize.Is4:
                    return "4";
                default:
                    return null;
            }
        }

        public string ToPlacement(Placement placement)
        {
            switch (placement)
            {
                case Placement.Bottom:
                    return "bottom";
                case Placement.Left:
                    return "left";
                case Placement.Right:
                    return "right";
                case Placement.Top:
                default:
                    return "top";
            }
        }

        public virtual string ToValidationStatus(ValidationStatus validationStatus)
        {
            switch (validationStatus)
            {
                case ValidationStatus.Success:
                    return "is-valid";
                case ValidationStatus.Error:
                    return "is-invalid";
                default:
                    return null;
            }
        }

        public virtual string ToCursor(Cursor cursor)
        {
            switch (cursor)
            {
                case Cursor.Pointer:
                    return "pointer";
                default:
                    return null;
            }
        }

        public virtual string ToFigureSize(FigureSize figureSize)
        {
            switch (figureSize)
            {
                case BlazorMasterPage.Components.FigureSize.Is16x16:
                    return "16x16";
                case BlazorMasterPage.Components.FigureSize.Is24x24:
                    return "24x24";
                case BlazorMasterPage.Components.FigureSize.Is32x32:
                    return "32x32";
                case BlazorMasterPage.Components.FigureSize.Is48x48:
                    return "48x48";
                case BlazorMasterPage.Components.FigureSize.Is64x64:
                    return "64x64";
                case BlazorMasterPage.Components.FigureSize.Is96x96:
                    return "96x96";
                case BlazorMasterPage.Components.FigureSize.Is128x128:
                    return "128x128";
                case BlazorMasterPage.Components.FigureSize.Is256x256:
                    return "256x256";
                case BlazorMasterPage.Components.FigureSize.Is512x512:
                    return "512x512";
                default:
                    return null;
            }
        }

        public virtual string ToCharacterCasing(CharacterCasing characterCasing)
        {
            switch (characterCasing)
            {
                case CharacterCasing.Upper:
                    return "upper";
                case CharacterCasing.Lower:
                    return "lower";
                case CharacterCasing.Title:
                    return "title";
                case CharacterCasing.Normal:
                default:
                    return null;
            }
        }

        public virtual string ToDividerType(DividerType dividerType)
        {
            switch (dividerType)
            {
                case BlazorMasterPage.Components.DividerType.Dashed:
                    return "dashed";
                case BlazorMasterPage.Components.DividerType.Dotted:
                    return "dotted";
                case BlazorMasterPage.Components.DividerType.TextContent:
                    return "text";
                case BlazorMasterPage.Components.DividerType.Solid:
                default:
                    return "solid";
            }
        }

    }
}
