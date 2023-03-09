using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMasterPage.Components.Services
{
    public interface IClassProvider
    {
        string TextEdit(bool plaintext);

        string TextEditSize(Size size);

        string TextEditColor(Color color);

        string TextEditValidation(ValidationStatus validationStatus);

        string MemoEdit();

        string MemoEditValidation(ValidationStatus validationStatus);

        string Select();

        string SelectMultiple();

        string SelectSize(Size size);

        string SelectValidation(ValidationStatus validationStatus);

        string NumericEdit(bool plaintext);

        string NumericEditSize(Size size);

        string NumericEditColor(Color color);

        string NumericEditValidation(ValidationStatus validationStatus);

        string DateEdit(bool plaintext);

        string DateEditSize(Size size);

        string DateEditColor(Color color);

        string DateEditValidation(ValidationStatus validationStatus);

        string TimeEdit(bool plaintext);

        string TimeEditSize(Size size);

        string TimeEditColor(Color color);

        string TimeEditValidation(ValidationStatus validationStatus);

        string ColorEdit();

        string Check();

        string CheckSize(Size size);

        string CheckInline();

        string CheckCursor(Cursor cursor);

        string CheckValidation(ValidationStatus validationStatus);

        string RadioGroup(bool buttons, Orientation orientation);

        string RadioGroupValidation(ValidationStatus validationStatus);

        string Radio(bool button);

        string RadioSize(bool button, Size size);

        string RadioInline(bool inline);

        string RadioCursor(Cursor cursor);

        string RadioValidation(ValidationStatus validationStatus);

        string Switch();

        string SwitchColor(Color color);

        string SwitchSize(Size size);

        string SwitchChecked(bool @checked);

        string SwitchCursor(Cursor cursor);

        string SwitchValidation(ValidationStatus validationStatus);

        string FileEdit();

        string FileEditValidation(ValidationStatus validationStatus);

        string Slider();

        string SliderColor(Color color);

        string Label();

        string LabelType(LabelType labelType);

        string LabelCursor(Cursor cursor);

        string Help();

        string ValidationSuccess();

        string ValidationSuccessTooltip();

        string ValidationError();

        string ValidationErrorTooltip();

        string ValidationNone();

        string ValidationSummary();

        string ValidationSummaryError();

        string Fields();

        string FieldsBody();

        string FieldsColumn();

        string Field();

        string FieldHorizontal();

        string FieldColumn();

        string FieldValidation(ValidationStatus validationStatus);

        string FieldJustifyContent(JustifyContent justifyContent);

        string FieldLabel();

        string FieldLabelHorizontal();

        string FieldBody();

        string FieldHelp();

        string ControlCheck();

        string ControlRadio();

        string ControlSwitch();

        string ControlFile();

        string ControlText();

        string Addons();

        string AddonsHasButton(bool hasButton);

        string Addon(AddonType addonType);

        string AddonLabel();

        string Inline();

        string Button();

        string ButtonColor(Color color);

        string ButtonOutline(Color color);

        string ButtonSize(Size size);

        string ButtonBlock();

        string ButtonActive();

        string ButtonLoading();

        string ButtonsAddons();

        string ButtonsToolbar();

        string ButtonsSize(Size size);

        string ButtonsOrientation(Orientation orientation);

        string CloseButton();

        string Dropdown();

        string DropdownGroup();

        string DropdownShow();

        string DropdownRight();

        string DropdownItem();

        string DropdownItemActive(bool active);

        string DropdownItemDisabled(bool disabled);

        string DropdownDivider();

        string DropdownMenu();

        string DropdownMenuVisible(bool visible);

        string DropdownMenuRight();

        string DropdownToggle();

        string DropdownToggleColor(Color color);

        string DropdownToggleOutline(Color color);

        string DropdownToggleSize(Size size);

        string DropdownToggleSplit();

        string DropdownToggleIcon(bool visible);

        string DropdownDirection(Direction direction);

        string DropdownTableResponsive();

        string Tabs(bool pills);

        string TabsCards();

        string TabsFullWidth();

        string TabsJustified();

        string TabsVertical();

        string TabItem();

        string TabItemActive(bool active);

        string TabItemDisabled(bool disabled);

        string TabLink();

        string TabLinkActive(bool active);

        string TabLinkDisabled(bool disabled);

        string TabsContent();

        string TabPanel();

        string TabPanelActive(bool active);

        string Steps();

        string StepItem();

        string StepItemActive(bool active);

        string StepItemCompleted(bool completed);

        string StepItemColor(Color color);

        string StepItemMarker();

        string StepItemDescription();

        string StepsContent();

        string StepPanel();

        string StepPanelActive(bool active);

        string Carousel();

        string CarouselSlides();

        string CarouselSlide();

        string CarouselSlideActive(bool active);

        string CarouselIndicators();

        string CarouselIndicator();

        string CarouselIndicatorActive(bool active);

        string CarouselFade(bool fade);

        string CarouselCaption();

        string Jumbotron();

        string JumbotronBackground(Background background);

        //string JumbotronTitle(JumbotronTitleSize jumbotronTitleSize);

        string JumbotronSubtitle();

        string CardDeck();

        string CardGroup();

        string Card();

        string CardWhiteText();

        string CardBackground(Background background);

        string CardActions();

        string CardBody();

        string CardFooter();

        string CardHeader();

        string CardImage();

        string CardTitle(bool insideHeader);

        string CardTitleSize(bool insideHeader, int? size);

        string CardSubtitle(bool insideHeader);

        string CardSubtitleSize(bool insideHeader, int size);

        string CardText();

        string CardLink();

        string ListGroup();

        string ListGroupFlush();

        string ListGroupItem();

        string ListGroupItemActive();

        string ListGroupItemDisabled();

        string Layout();

        string LayoutHasSider();

        string LayoutContent();

        string LayoutHeader();

        string LayoutHeaderFixed();

        string LayoutFooter();

        string LayoutFooterFixed();

        string LayoutSider();

        string LayoutSiderContent();

        string LayoutLoading();

        string LayoutRoot();

        string Container();

        string ContainerFluid();

        string Bar();

        string BarBackground(Background background);

        string BarAlignment(Alignment alignment);

        string BarBreakpoint(Breakpoint breakpoint);

        string BarMode(BarMode mode);

        string BarItem(BarMode mode);

        string BarItemActive(BarMode mode);

        string BarItemDisabled(BarMode mode);

        string BarItemHasDropdown(BarMode mode);

        string BarItemHasDropdownShow(BarMode mode);

        string BarLink(BarMode mode);

        string BarLinkDisabled(BarMode mode);

        string BarBrand(BarMode mode);

        string BarToggler(BarMode mode, BarTogglerMode togglerMode);

        string BarTogglerCollapsed(BarMode mode, BarTogglerMode togglerMode, bool isShow);

        string BarMenu(BarMode mode);

        string BarMenuShow(BarMode mode);

        string BarStart(BarMode mode);

        string BarEnd(BarMode mode);

        string BarDropdown(BarMode mode);

        string BarDropdownShow(BarMode mode);

        string BarDropdownToggle(BarMode mode);

        string BarDropdownItem(BarMode mode);

        string BarTogglerIcon(BarMode mode);

        string BarDropdownMenu(BarMode mode);

        string BarDropdownMenuVisible(BarMode mode, bool visible);

        string BarDropdownMenuRight(BarMode mode);

        string BarDropdownMenuContainer(BarMode mode);

        string BarCollapsed(BarMode mode);

        string BarLabel();

        string Accordion();

        string Collapse();

        string CollapseActive(bool active);

        string CollapseHeader();

        string CollapseBody();

        string CollapseBodyActive(bool active);

        string CollapseBodyContent();

        string Row();

        string Column(bool hasSizes);

        string Column(ColumnWidth columnWidth, IEnumerable<(Breakpoint breakpoint, bool offset)> rules);

        string Display(DisplayType displayType, Breakpoint breakpoint, DisplayDirection direction);

        string Display(DisplayType displayType, IEnumerable<(Breakpoint breakpoint, DisplayDirection direction)> rules);

        string Alert();

        string AlertColor(Color color);

        string AlertDismisable();

        string AlertFade();

        string AlertShow();

        string AlertHasMessage();

        string AlertHasDescription();

        string AlertMessage();

        string AlertDescription();

        string Modal();

        string ModalFade();

        string ModalVisible(bool visible);

        string ModalBackdrop();

        string ModalBackdropFade();

        string ModalBackdropVisible(bool visible);

        string ModalContent(bool dialog);

        //string ModalContentSize(ModalSize modalSize);

        string ModalContentCentered();

        string ModalBody();

        string ModalHeader();

        string ModalFooter();

        string ModalTitle();

        string Pagination();

        string PaginationSize(Size size);

        string PaginationItem();

        string PaginationItemActive();

        string PaginationItemDisabled();

        string PaginationLink();

        string PaginationLinkActive();

        string PaginationLinkDisabled();

        string Progress();

        string ProgressSize(Size size);

        string ProgressBar();

        string ProgressBarSize(Size size);

        string ProgressBarColor(Background background);

        string ProgressBarStriped();

        string ProgressBarAnimated();

        string ProgressBarWidth(int width);

        string Chart();

        string BackgroundColor(Background background);

        string Title();

        string TitleSize(int size);

        string Table();

        string TableFullWidth();

        string TableStriped();

        string TableHoverable();

        string TableBordered();

        string TableNarrow();

        string TableBorderless();

        string TableHeader();

        string TableHeaderCell();

        string TableHeaderCellTextAlignment(TextAlignment textAlignment);

        string TableFooter();

        string TableBody();

        string TableRow();

        string TableRowColor(Color color);

        string TableRowBackground(Background background);

        string TableRowTextColor(TextColor textColor);

        string TableRowHoverCursor();

        string TableRowIsSelected();

        string TableRowHeader();

        string TableRowCell();

        string TableRowCellColor(Color color);

        string TableRowCellBackground(Background background);

        string TableRowCellTextColor(TextColor textColor);

        string TableRowCellTextAlignment(TextAlignment textAlignment);

        string TableResponsive();

        string Badge();

        string BadgeColor(Color color);

        string BadgePill();

        string BadgeClose();

        string Media();

        string MediaLeft();

        string MediaRight();

        string MediaBody();

        string TextColor(TextColor textColor);

        string TextAlignment(TextAlignment textAlignment);

        string TextTransform(TextTransform textTransform);

        string TextWeight(TextWeight textWeight);

        string TextItalic();

        string HeadingSize(HeadingSize headingSize);

        string DisplayHeadingSize(DisplayHeadingSize displayHeadingSize);

        string Paragraph();

        string ParagraphColor(TextColor textColor);

        string Figure();

        string FigureSize(FigureSize figureSize);

        string FigureImage();

        string FigureImageRounded();

        string FigureCaption();

        string Breadcrumb();

        string BreadcrumbItem();

        string BreadcrumbItemActive();

        string BreadcrumbLink();

        string Tooltip();

        string TooltipPlacement(Placement placement);

        string TooltipMultiline();

        string TooltipAlwaysActive();

        string TooltipFade();

        string TooltipInline();

        string Divider();

        string DividerType(DividerType dividerType);

        string Show();

        string Fade();

        string Active();

        string Disabled();

        string Collapsed();

        string Spacing(Spacing spacing, SpacingSize spacingSize, Side side, Breakpoint breakpoint);

        string Spacing(Spacing spacing, SpacingSize spacingSize, IEnumerable<(Side side, Breakpoint breakpoint)> rules);

        string FlexAlignment(Alignment alignment);

        string Casing(CharacterCasing characterCasing);

        string ToSize(Size size);

        string ToBreakpoint(Breakpoint breakpoint);

        string ToColor(Color color);

        string ToBackground(Background color);

        string ToTextColor(TextColor textColor);

        string ToFloat(Float @float);

        string ToSpacing(Spacing spacing);

        string ToSide(Side side);

        string ToAlignment(Alignment alignment);

        string ToTextAlignment(TextAlignment textAlignment);

        string ToTextTransform(TextTransform textTransform);

        string ToTextWeight(TextWeight textWeight);

        string ToColumnWidth(ColumnWidth columnWidth);

        string ToDisplayType(DisplayType displayType);

        string ToDisplayDirection(DisplayDirection displayDirection);

        //string ToModalSize(ModalSize modalSize);

        string ToSpacingSize(SpacingSize spacingSize);

        string ToJustifyContent(JustifyContent justifyContent);

        //string ToScreenreader(Screenreader screenreader);

        string ToHeadingSize(HeadingSize headingSize);

        string ToDisplayHeadingSize(DisplayHeadingSize displayHeadingSize);

        string ToJumbotronTitleSize(JumbotronTitleSize jumbotronTitleSize);

        string ToPlacement(Placement placement);

        string ToFigureSize(FigureSize figureSize);

        string ToCharacterCasing(CharacterCasing characterCasing);

        string ToBarMode(BarMode mode);

        string ToBarCollapsedMode(BarCollapseMode collapseMode);

        bool UseCustomInputStyles { get; set; }

        string Provider { get; }
    }
}
